using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;
using System.Data.Entity;

namespace StackOverflow.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnswerQuestion(int id)
        {
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                //var list = context.Questions.OrderBy(x => x.CreationDate).ToList();

                //var question = context.Questions.Where(q => q.Id == id)
                var question = context.Questions
                        .Where(q => q.Id == id)
                        .Include(q => q.Category)
                        .Include(q => q.User)
                        .Include(q => q.Answers)
                        .Include(q => q.Answers.Select(lp => lp.User))
                        .First();
                
                question.ViewCount += 1;
                context.SaveChanges();

                /*
                for(int i = 0; i < question.Answers.Count; i++)
                {
                    context.Questions.Include(q => q.Answers[i]);
                }
                */

                /*
                context.Entry(question).Reference(s => s.Category).Load();
                context.Entry(question).Reference(s => s.User).Load();
                context.Entry(question).Collection(s => s.Answers).Load();
                
                var answers = context.Entry(question).Collection(s => s.Answers);
                foreach (var item in answers.)
                {
                    context.Entry(item).Reference(i => i.User).Load();
                }

                /*
                var category = context.Categories.Where(c => c.Id == question.Category.Id).First();
                question.Category = category;
                Console.WriteLine(category);
                
                var answers = context.Answers.Where(a => a.Question.Id == question.Id).ToList();
                question.Answers = answers;
                Console.WriteLine(answers);
                */
                return View(question);
            }

        }
    }
}
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

        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Question question)
        {
            try
            {
                using (QuestionAnswerContext context = new QuestionAnswerContext())
                {
                    question.Category = context.Categories.Find(1);
                    question.User = context.Users.Find(1);

                    question.CreationDate = DateTime.Now;

                    question.AnswerCount = 0;
                    question.ViewCount = 0;
                    question.VoteCount = 0;

                    context.Questions.Add(question);
                    context.SaveChanges();

                    return RedirectToAction("Questions", "Home", null);
                }
            }
            catch
            {
                return View();
            }
        }
    

        public ActionResult AnswerQuestion(int id)
        {
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {

                var question = context.Questions
                        .Where(q => q.Id == id)
                        .Include(q => q.Category)
                        .Include(q => q.User)
                        .Include(q => q.Answers)
                        .Include(q => q.Answers.Select(lp => lp.User))
                        .First();
                
                question.ViewCount += 1;
                context.SaveChanges();


                var questionanswermodel = new QuestionAnswer();
                questionanswermodel.Question = question;
               
                return View(questionanswermodel);
            }

        }

        [HttpPost]
        public ActionResult AnswerQuestion(QuestionAnswer questionAnswermodel)
        {
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var questionId = questionAnswermodel.Question.Id;
                var newAnswer = questionAnswermodel.Answer;

                var question = context.Questions.Find(questionId);
                newAnswer.Question = question;

                question.AnswerCount += 1;
                context.Entry(question).State = EntityState.Modified;

                //Using default user as ID = 1, since we still dont have the login feature
                newAnswer.User = context.Users.Find(1);
                newAnswer.CreationDate = DateTime.Now;

                context.Answers.Add(newAnswer);
                context.SaveChanges();

                var updatedquestion = context.Questions
                        .OrderBy(q => q.CreationDate)
                        .Where(q => q.Id == questionId)
                        .Include(q => q.Category)
                        .Include(q => q.User)
                        .Include(q => q.Answers)
                        .Include(q => q.Answers.Select(lp => lp.User))
                        .First();

                var questionanswermodel = new QuestionAnswer();
                questionanswermodel.Question = updatedquestion;

                return View(questionanswermodel);
            }

        }



    }
}
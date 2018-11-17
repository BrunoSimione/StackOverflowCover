using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.Message = "Your categories page.";
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var list = context.Categories.OrderBy(x => x.Id).ToList();
                return View(list);
            }
        }

        public ActionResult Questions()
        {
            ViewBag.Message = "Your questions page.";
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var list = context.Questions.OrderBy(x => x.CreationDate).ToList();
                return View(list);
            }
        }
    }
}
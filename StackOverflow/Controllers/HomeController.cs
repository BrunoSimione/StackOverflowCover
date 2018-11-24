﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Models;
using System.Data.Entity;

namespace StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var list = context.Questions
                    .OrderBy(x => x.CreationDate)
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Take(5)
                    .ToList();
                return View(list);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Website created by Bruno Simione Beltrame (N01220860)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact me in:";

            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.Message = "Your categories page.";
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var list = context.Categories
                    .OrderBy(x => x.Id)
                    .ToList();

                return View(list);
            }
        }

        public ActionResult Questions()
        {
            ViewBag.Message = "Your questions page.";
            using (QuestionAnswerContext context = new QuestionAnswerContext())
            {
                var list = context.Questions
                    .OrderBy(x => x.CreationDate)
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .ToList();
                return View(list);
            }
        }
    }
}
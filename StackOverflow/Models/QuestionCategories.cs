using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Models
{
    public class QuestionCategories
    {
        public Question Question { get; set; }
        public List<Category> Categories { get; set; }
    }
}
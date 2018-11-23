using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Models
{
    public class QuestionAnswer
    {
        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}
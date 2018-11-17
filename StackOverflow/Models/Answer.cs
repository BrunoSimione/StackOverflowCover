using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverflow.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
    }
}
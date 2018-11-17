using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverflow.Models
{
    public class Category
    {
        public Category()
        {
            Question = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Question> Question { get; set; }
    }
}
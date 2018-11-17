using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverflow.Models
{
    public class User
    {
        public User()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
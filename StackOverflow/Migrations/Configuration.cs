namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StackOverflow.Models.QuestionAnswerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StackOverflow.Models.QuestionAnswerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = 1, Name = "C#" },
                new Category() { Id = 2, Name = "Java" },
                new Category() { Id = 3, Name = "Asp.Net" }
                );

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Name = "John", Email = "john@john.com", Password = "123456"},
                new User() { Id = 2, Name = "Mary", Email = "mary@mary.com", Password = "123456" },
                new User() { Id = 3, Name = "Peter", Email = "peter@peter.com", Password = "123456" }
                );

            context.Questions.AddOrUpdate(x => x.Id,
                new Question() { Id = 1, QuestionName = "How can I do XYZ?", CreationDate = DateTime.Now, ViewCount = 0, AnswerCount = 0, VoteCount = 0, User = context.Users.Find(1), Category = context.Categories.Find(1) },
                new Question() { Id = 2, QuestionName = "Is it possible to do ABC?", CreationDate = DateTime.Now, ViewCount = 0, AnswerCount = 0, VoteCount = 0, User = context.Users.Find(1), Category = context.Categories.Find(2) },
                new Question() { Id = 3, QuestionName = "Is it possible to do ABCXYZ?", CreationDate = DateTime.Now, ViewCount = 0, AnswerCount = 0, VoteCount = 0, User = context.Users.Find(2), Category = context.Categories.Find(1) }
                );

            context.Answers.AddOrUpdate(x => x.Id,
                new Answer() { Id = 1, CreationDate = DateTime.Now, Text = "You should do qwerty", Question = context.Questions.Find(1), User = context.Users.Find(2)},
                new Answer() { Id = 2, CreationDate = DateTime.Now, Text = "You should do qwertyzxc", Question = context.Questions.Find(1), User = context.Users.Find(3)},
                new Answer() { Id = 3, CreationDate = DateTime.Now, Text = "You should do abc", Question = context.Questions.Find(2), User = context.Users.Find(3) }
                );
        }
    }
}

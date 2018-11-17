namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Id", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "Id" });
            DropPrimaryKey("dbo.Questions");
            AddColumn("dbo.Questions", "Category_Id", c => c.Int());
            AlterColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Questions", "Id");
            CreateIndex("dbo.Questions", "Category_Id");
            AddForeignKey("dbo.Questions", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.Questions", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Category_Id");
            AddPrimaryKey("dbo.Questions", "Id");
            CreateIndex("dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Questions", "Id", "dbo.Categories", "Id");
        }
    }
}

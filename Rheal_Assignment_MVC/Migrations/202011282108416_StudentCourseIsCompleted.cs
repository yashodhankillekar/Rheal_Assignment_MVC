namespace Rheal_Assignment_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentCourseIsCompleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCourses", "isCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.StudentCourses", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourses", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.StudentCourses", "isCompleted");
        }
    }
}

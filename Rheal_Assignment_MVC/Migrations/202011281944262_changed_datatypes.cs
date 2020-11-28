namespace Rheal_Assignment_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_datatypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentCourses", "StudentId", c => c.String());
            AlterColumn("dbo.StudentCourses", "CourseId", c => c.String());
            AlterColumn("dbo.TrainerCourses", "TrainerId", c => c.String());
            AlterColumn("dbo.TrainerCourses", "CourseId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainerCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.TrainerCourses", "TrainerId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCourses", "StudentId", c => c.Int(nullable: false));
        }
    }
}

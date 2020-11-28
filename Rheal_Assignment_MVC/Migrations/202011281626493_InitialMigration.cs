namespace Rheal_Assignment_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaOfInterests",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RowId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseRowId = c.Int(nullable: false, identity: true),
                        CourseId = c.String(),
                        CourseName = c.String(nullable: false, maxLength: 50),
                        CourseNoOfModules = c.Int(nullable: false),
                        CoursePrice = c.Int(nullable: false),
                        CourseTrainerId = c.Int(nullable: false),
                        CourseTrainer_RowId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseRowId)
                .ForeignKey("dbo.Trainers", t => t.CourseTrainer_RowId)
                .Index(t => t.CourseTrainer_RowId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(),
                        ExpertiseRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RowId)
                .ForeignKey("dbo.AreaOfInterests", t => t.ExpertiseRowId, cascadeDelete: true)
                .Index(t => t.ExpertiseRowId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RowId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRowId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        StudentName = c.String(nullable: false, maxLength: 20),
                        StudentAddress = c.String(nullable: false, maxLength: 150),
                        StudentCity = c.String(nullable: false, maxLength: 50),
                        StudentDOB = c.DateTime(nullable: false),
                        StudentMobileNo = c.String(nullable: false, maxLength: 10),
                        StudentAOIRowId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.StudentRowId)
                .ForeignKey("dbo.AreaOfInterests", t => t.StudentAOIRowId, cascadeDelete: true)
                .Index(t => t.StudentAOIRowId);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        RowId = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentAOIRowId", "dbo.AreaOfInterests");
            DropForeignKey("dbo.Courses", "CourseTrainer_RowId", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "ExpertiseRowId", "dbo.AreaOfInterests");
            DropIndex("dbo.Students", new[] { "StudentAOIRowId" });
            DropIndex("dbo.Trainers", new[] { "ExpertiseRowId" });
            DropIndex("dbo.Courses", new[] { "CourseTrainer_RowId" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
            DropTable("dbo.AreaOfInterests");
        }
    }
}

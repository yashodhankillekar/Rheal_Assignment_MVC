namespace Rheal_Assignment_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "ExpertiseRowId", "dbo.AreaOfInterests");
            DropIndex("dbo.Trainers", new[] { "ExpertiseRowId" });
            RenameColumn(table: "dbo.Trainers", name: "ExpertiseRowId", newName: "Expertise_RowId");
            AddColumn("dbo.StudentCourses", "CourseId_CourseRowId", c => c.Int());
            AddColumn("dbo.StudentCourses", "StudentId_StudentRowId", c => c.Int());
            AlterColumn("dbo.Trainers", "Expertise_RowId", c => c.Int());
            CreateIndex("dbo.Trainers", "Expertise_RowId");
            CreateIndex("dbo.StudentCourses", "CourseId_CourseRowId");
            CreateIndex("dbo.StudentCourses", "StudentId_StudentRowId");
            AddForeignKey("dbo.StudentCourses", "CourseId_CourseRowId", "dbo.Courses", "CourseRowId");
            AddForeignKey("dbo.StudentCourses", "StudentId_StudentRowId", "dbo.Students", "StudentRowId");
            AddForeignKey("dbo.Trainers", "Expertise_RowId", "dbo.AreaOfInterests", "RowId");
            DropColumn("dbo.Courses", "CourseTrainerId");
            DropColumn("dbo.StudentCourses", "StudentId");
            DropColumn("dbo.StudentCourses", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourses", "CourseId", c => c.String());
            AddColumn("dbo.StudentCourses", "StudentId", c => c.String());
            AddColumn("dbo.Courses", "CourseTrainerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Trainers", "Expertise_RowId", "dbo.AreaOfInterests");
            DropForeignKey("dbo.StudentCourses", "StudentId_StudentRowId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId_CourseRowId", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "StudentId_StudentRowId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId_CourseRowId" });
            DropIndex("dbo.Trainers", new[] { "Expertise_RowId" });
            AlterColumn("dbo.Trainers", "Expertise_RowId", c => c.Int(nullable: false));
            DropColumn("dbo.StudentCourses", "StudentId_StudentRowId");
            DropColumn("dbo.StudentCourses", "CourseId_CourseRowId");
            RenameColumn(table: "dbo.Trainers", name: "Expertise_RowId", newName: "ExpertiseRowId");
            CreateIndex("dbo.Trainers", "ExpertiseRowId");
            AddForeignKey("dbo.Trainers", "ExpertiseRowId", "dbo.AreaOfInterests", "RowId", cascadeDelete: true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rheal_Assignment_MVC.Models
{
    public class StudentCourse
    {
        [Key]
        public int RowId { get; set; }
        public virtual Student StudentId { get; set; }
        public virtual Course CourseId { get; set; }
        public bool isCompleted { get; set; }
    }

    public class TrainerCourse
    {
        [Key]
        public int RowId { get; set; }
        public string TrainerId { get; set; }
        public string CourseId { get; set; }
    }

    public class Student
    {
        [Key]
        public int StudentRowId { get; set; }
        public string StudentId { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(150, ErrorMessage = "150 characters max")]
        public string StudentAddress { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(50, ErrorMessage = "50 characters max")]
        public string StudentCity { get; set; }

        public DateTime StudentDOB { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(10, ErrorMessage = "10 characters max")]
        public string StudentMobileNo { get; set; }

        public int StudentAOIRowId { get; set; }
        public virtual AreaOfInterest StudentAOI { get; set; }

        public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }


    public class AreaOfInterest
    {
        [Key]
        public int RowId { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(20, ErrorMessage = "20 characters max")]
        public string Name { get; set; }
    }

    public class Trainer
    {
        [Key]
        public int RowId { get; set; }

        public string TrainerId { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(50, ErrorMessage = "50 characters max")]
        public string Name { get; set; }

        public string UserId { get; set; }

        //public int ExpertiseRowId { get; set; }
        public virtual AreaOfInterest Expertise { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }
        public string CourseId { get; set; }

        [Required(ErrorMessage = "It is Required")]
        [StringLength(50, ErrorMessage = "50 characters max")]
        public string CourseName { get; set; }
        public int CourseNoOfModules { get; set; }
        public int CoursePrice { get; set; }

        //public int CourseTrainerId { get; set; }
        public virtual Trainer CourseTrainer { get; set; }

    }


    public class Models
    {
    }
}
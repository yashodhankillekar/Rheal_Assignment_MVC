﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.BizRepositories;
using Rheal_Assignment_MVC.Models;

namespace Rheal_Assignment_MVC.Controllers
{
    public class StudentCourseController : Controller
    {
        IBizRepository<StudentCourse, int> studentCourseRepo;
        RhealAssignmentDBContext context;

        public StudentCourseController()
        {
            studentCourseRepo = new StudentCourseBizRepository();
            context = new RhealAssignmentDBContext();
        }

        public ActionResult showCourse(int course_id)
        {
            //show course Details
            return View();
        }

        //authorize so only registered students can enroll
        [Authorize(Roles = "Student")]
        public ActionResult EnrollIntoCourse(int course_id, int student_id)
        {

            //prepare object for making an entry in database
            StudentCourse cs = new StudentCourse();
            cs.CourseId = context.Courses.Where(e => e.CourseRowId == course_id).FirstOrDefault();
            cs.StudentId = context.Students.Where(e => e.StudentRowId == student_id).FirstOrDefault();
            cs.isCompleted = false;

            //check if student has already enrolled in the same course
            List<StudentCourse> temp = context.StudentCourses.Where(e => e.StudentId.StudentRowId == student_id).ToList();
            StudentCourse temp2 = temp.Where(e => e.CourseId.CourseRowId == course_id).FirstOrDefault();
            if (temp2 == null)
            {
                //create row in database
                //studentCourseRepo.create(cs);
                context.StudentCourses.Add(cs);
                context.SaveChanges();
            }
            

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetEnrolledCourses(string user_id)
        {
            //get Student from user_id
            Student std = context.Students.Where(e => e.UserId == user_id).FirstOrDefault();

            //get courses enrolled by user
            List<StudentCourse> result = context.StudentCourses.Where(e => e.StudentId.StudentRowId == std.StudentRowId).ToList();
            return View(result);
        }

        // GET: StudentCourse
        public ActionResult Index()
        {
            return View();
        }
    }
}
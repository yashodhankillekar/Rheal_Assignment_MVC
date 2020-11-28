using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;

namespace Rheal_Assignment_MVC.Controllers
{
    public class CourseController : Controller
    {
        IBizRepository<Course, int> courseRepo;
        RhealAssignmentDBContext context;

        public CourseController()
        {
            courseRepo = new CourseBizRepository();
            context = new RhealAssignmentDBContext();
        }

        // GET: Course
        public ActionResult Index()
        {
            var result = courseRepo.getData();
            return View(result);
        }

        public ActionResult getCourses(string user_id)
        {
            var result = courseRepo.getData();
            result = result.Where(e => e.CourseTrainer.UserId == user_id).ToList();
            return View(result);
        }

        public ActionResult addCourse(string user_id)
        {
            var temp_trainer = context.Trainers.Where(e => e.UserId == user_id).FirstOrDefault();
            var result = new Course();
            result.CourseTrainer = temp_trainer;
            //generate Course Id
            if (context.Courses.Count() > 0)
            {
                string courseid = context.Courses.OrderByDescending(e => e.CourseId).First().CourseId;
                string[] temp = courseid.Split('-');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                courseid = temp[0] + '-' + temp[1];
                result.CourseId = courseid;
            }
            else
            {
                result.CourseId = "C-001";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult addCourse(Course cr)
        {
            if (ModelState.IsValid)
            {
                courseRepo.create(cr);
                return RedirectToAction("Index", "Home");
            }
            return View(cr);
        }

        public ActionResult Create()
        {
            var result = new Course();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Course cour)
        {
            if (ModelState.IsValid)
            {
                courseRepo.create(cour);
                return RedirectToAction("Index");
            }
            return View(cour);
        }

        public ActionResult Edit(int id)
        {
            var result = courseRepo.getData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course cour)
        {
            if (ModelState.IsValid)
            {
                courseRepo.update(id, cour);
                return RedirectToAction("Index");
            }
            return View(cour);
        }

        public ActionResult Delete(int id)
        {
            var result = courseRepo.delete(id);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;

namespace Rheal_Assignment_MVC.Controllers
{
    public class StudentController : Controller
    {
        IBizRepository<Student, int> studentRepo;
        RhealAssignmentDBContext context;

        public StudentController()
        {
            studentRepo = new StudentBizRepository();
            context = new RhealAssignmentDBContext();
        }

        // GET: Student
        public ActionResult Index()
        {
            var result = studentRepo.getData();
            return View(result);
        }

        public ActionResult makeEntry(string user_id)
        {
            //get Area of interests for dropdown
            ViewBag.AOI = context.AreaOfInterests.ToList();

            var result = new Student();
            result.UserId = user_id;

            //generate Student Id
            if (context.Students.Count() > 0)
            {
                string studentId = context.Students.OrderByDescending(e => e.StudentId).First().StudentId;
                string[] temp = studentId.Split('-');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                studentId = temp[0] + '-' + temp[1];
                result.StudentId = studentId;
            }
            else
            {
                result.StudentId = "Stud-001";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult makeEntry(Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.create(stud);
                return RedirectToAction("Index","Home");
            }
            return View(stud);
        }

        public ActionResult Create()
        {
            //populate dropdowns

            var result = new Student();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.create(stud);
                return RedirectToAction("Index");
            }
            return View(stud);
        }

        public ActionResult Edit(int id)
        {
            var result = studentRepo.getData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student stud)
        {
            if (ModelState.IsValid)
            {
                studentRepo.update(id, stud);
                return RedirectToAction("Index");
            }
            return View(stud);
        }

        public ActionResult Delete(int id)
        {
            var result = studentRepo.delete(id);
            return RedirectToAction("Index");
        }
    }
}
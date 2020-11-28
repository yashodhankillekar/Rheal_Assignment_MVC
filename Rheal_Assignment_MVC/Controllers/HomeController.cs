using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;
using Microsoft.AspNet.Identity;

namespace Rheal_Assignment_MVC.Controllers
{
    public class HomeController : Controller
    {
        IBizRepository<Course, int> courseRepo;
        RhealAssignmentDBContext context;

        public HomeController()
        {
            courseRepo = new CourseBizRepository();
            context = new RhealAssignmentDBContext();
        }

        public ActionResult Index()
        {
            //get all courses and show courses
            var result = courseRepo.getData();

            //store logged in user data in viewbag
            if (User != null && User.IsInRole("Student"))
            {
                string userId = User.Identity.GetUserId();
                Student user = context.Students.Where(e => e.UserId == userId).FirstOrDefault();
                ViewBag.loggedInUser = user.StudentRowId;
            }
            
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
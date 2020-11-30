using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace Rheal_Assignment_MVC.Controllers
{
    public class HomeController : Controller
    {
        IBizRepository<Course, int> courseRepo;
        RhealAssignmentDBContext context;
        ApplicationDbContext appdbContext;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public HomeController()
        {
            courseRepo = new CourseBizRepository();
            context = new RhealAssignmentDBContext();
            appdbContext = new ApplicationDbContext();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult SearchResult(string query)
        {
            //get courses based on query
            var result = courseRepo.getData();
            result = result.Where(e => e.CourseName.Contains(query)).ToList();

            //store logged in user data in viewbag
            if (User != null && User.IsInRole("Student"))
            {
                string userId = User.Identity.GetUserId();
                Student user = context.Students.Where(e => e.UserId == userId).FirstOrDefault();
                ViewBag.loggedInUser = user.StudentRowId;
            }

            return View(result);
        }

        public async Task<ActionResult> Index()
        {
            //Check for initial RUN
            if (appdbContext.Users.Count() == 0)
            {
                //make new roles for Administrator, Trainer, Student
                IdentityRole adminrole = new IdentityRole() { Name = "Administrator" };
                IdentityRole trainerrole = new IdentityRole() { Name = "Trainer" };
                IdentityRole studentrole = new IdentityRole() { Name = "Student" };

                appdbContext.Roles.Add(adminrole);
                appdbContext.Roles.Add(trainerrole);
                appdbContext.Roles.Add(studentrole);
                appdbContext.SaveChanges();

                //make Default Area of interest entry as "Computer Science"
                AreaOfInterest aoi = new AreaOfInterest() { Name = "Computer Science" };
                context.AreaOfInterests.Add(aoi);
                context.SaveChanges();

                //register new user Administrator
                RegisterViewModel model = new RegisterViewModel();
                model.Email = "Administrator@app.com";
                model.Password = "Password@123456";
                model.ConfirmPassword = "Password@123456";
                string Role = "Administrator";

                ApplicationUser user = new ApplicationUser();
                user.UserName = "Administrator@app.com";
                user.Email = "Administrator@app.com";

                var res = await UserManager.CreateAsync(user, model.Password);
                //assign administrator user to Administrator role
                UserManager.AddToRole(user.Id, Role);


            }



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
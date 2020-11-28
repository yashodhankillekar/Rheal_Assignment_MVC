using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;

namespace Rheal_Assignment_MVC.Controllers
{
    public class TrainerController : Controller
    {
        IBizRepository<Trainer, int> trainerRepo;
        RhealAssignmentDBContext context;

        public TrainerController()
        {
            trainerRepo = new TrainerBizRepository();
            context = new RhealAssignmentDBContext();
        }

        // GET: Trainer
        public ActionResult Index()
        {
            var result = trainerRepo.getData();
            return View(result);
        }

        public ActionResult makeEntry(string user_id)
        {
            //get Area of interests for dropdown
            ViewBag.AOI = context.AreaOfInterests.ToList();

            var result = new Trainer();
            result.UserId = user_id;


            //generate Trainer Id
            if (context.Trainers.Count() > 0)
            {
                string trainId = context.Trainers.OrderByDescending(e => e.TrainerId).First().TrainerId;
                string[] temp = trainId.Split('-');
                temp[1] = (Convert.ToInt32(temp[1]) + 1).ToString("000");
                trainId = temp[0] + '-' + temp[1];
                result.TrainerId = trainId;
            }
            else
            {
                result.TrainerId = "Tr-001";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult makeEntry(Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainerRepo.create(train);
                return RedirectToAction("Index", "Home");
            }
            return View(train);
            
        }

        public ActionResult Create()
        {
            //ViewBag.dob = "StudentDOB";
            var result = new Trainer();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainerRepo.create(train);
                return RedirectToAction("Index");
            }
            return View(train);
        }

        public ActionResult Edit(int id)
        {
            var result = trainerRepo.getData(id);
            return View(result);
        }

        public ActionResult Edit(int id, Trainer train)
        {
            if (ModelState.IsValid)
            {
                trainerRepo.update(id, train);
                return RedirectToAction("Index");
            }
            return View(train);
        }

        public ActionResult Delete(int id)
        {
            var result = trainerRepo.delete(id);
            return RedirectToAction("Index");
        }
    }
}
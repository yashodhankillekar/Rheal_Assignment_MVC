using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rheal_Assignment_MVC.Models;
using Rheal_Assignment_MVC.BizRepositories;

namespace Rheal_Assignment_MVC.Controllers
{
    public class AreaOfInterestController : Controller
    {
        IBizRepository<AreaOfInterest, int> areaOfInterestRepo;

        public AreaOfInterestController()
        {
            areaOfInterestRepo = new AreaOfInterestBizRepository();
        }

        // GET: AreaOfInterest
        public ActionResult Index()
        {
            var result = areaOfInterestRepo.getData();
            return View(result);
        }

        public ActionResult Create()
        {
            var result = new AreaOfInterest();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(AreaOfInterest aoi)
        {
            if (ModelState.IsValid)
            {
                areaOfInterestRepo.create(aoi);
                return RedirectToAction("Index");
            }
            return View(aoi);
        }

        public ActionResult Edit(int id)
        {
            var result = areaOfInterestRepo.getData(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, AreaOfInterest aoi)
        {
            if (ModelState.IsValid)
            {
                areaOfInterestRepo.update(id, aoi);
                return RedirectToAction("Index");
            }
            return View(aoi);
        }

        public ActionResult Delete(int id)
        {
            var result = areaOfInterestRepo.delete(id);
            return RedirectToAction("Index");
        }
    }
}
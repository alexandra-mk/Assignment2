using Assignment2.Context;
using Assignment2.Models;
using Assignment2.Models.Queries;
using Assignment2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Assignment2.RepositoryServices.Persistance;

namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        UnitOfWork unit;

        public TrainerController()
        {
            unit = new UnitOfWork(db);
        }
        // GET: Trainer
        public ActionResult Index(TrainerSearchQuery query, string sortOrder, int? page, int? pSize)
        {
            ViewBag.trainers = "Trainers";
            var trainers = unit.Trainers.GetAll();
            ViewBag.currentFirstname = query.searchFirstName;
            ViewBag.currentLastname = query.searchLastName;
            ViewBag.currentSubject = query.searchSubject;
            trainers = unit.Trainers.Filter(trainers, query);

          

            switch (sortOrder)
            {
                case "FirstNameAsc": trainers = trainers.OrderBy(x => x.FirstName).ToList(); break;
                case "FirstNameDesc": trainers = trainers.OrderByDescending(x => x.FirstName).ToList(); break;
                case "LastNameAsc": trainers = trainers.OrderBy(x => x.LastName).ToList(); break;
                case "LastNameDesc": trainers = trainers.OrderByDescending(x => x.LastName).ToList(); break;
                default: trainers = trainers.OrderBy(x => x.ID).ToList(); break;
            }

            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;
            return View(trainers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            ViewBag.details = "Trainer Details";
            var trainer = unit.Trainers.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.add = "Add Trainer";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Insert(trainer);
                unit.Complete();
                ShowAlert($"Trainer {trainer.FirstName} {trainer.LastName} has been successfully added!");
                return RedirectToAction("Index");
            }
            ViewBag.add = "Add Trainer";
            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var trainer = unit.Trainers.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            unit.Trainers.Delete(trainer);
            unit.Complete();
            ShowAlert($"Trainer {trainer.FirstName} {trainer.LastName} has been successfully deleted!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            ViewBag.update = "Update Trainer";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = unit.Trainers.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Trainer trainer)
        {
            ViewBag.update = "Update Trainer";
            if (ModelState.IsValid)
            {
                unit.Trainers.Update(trainer);
                unit.Complete();
                ShowAlert($"Trainer with ID {trainer.ID} has been successfully updated!");
                return RedirectToAction("Index");
            }
            return View(trainer);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }

       
    }
}
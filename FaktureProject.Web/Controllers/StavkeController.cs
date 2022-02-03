using FaktureProject.Data.Models;
using FaktureProject.Data.Services;
using FaktureProject.Data.UkupneCijene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaktureProject.Web.Controllers
{
    [Authorize]
    public class StavkeController : Controller
    {
        private readonly IStavkaData db;
        private FaktureProjectDbContext data = new FaktureProjectDbContext();
        public StavkeController(IStavkaData db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FakturaId = new SelectList(data.Fakture, "Id", "BrojFakture");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                db.Add(stavka);
                return RedirectToAction("Index");
            }
            ViewBag.FakturaId = new SelectList(data.Fakture, "Id", "BrojFakture", stavka.FakturaId);
            return View(stavka);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            ViewBag.FakturaId = new SelectList(data.Fakture, "Id", "BrojFakture");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                db.Update(stavka);
                return RedirectToAction("Index");
            }
            ViewBag.FakturaId = new SelectList(data.Fakture, "Id", "BrojFakture", stavka.FakturaId);
            return View(stavka);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
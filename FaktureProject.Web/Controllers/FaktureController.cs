using FaktureProject.Data.Models;
using FaktureProject.Data.Models.MEF;
using FaktureProject.Data.Services;
using FaktureProject.Data.UkupneCijene;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaktureProject.Web.Controllers
{
    [Authorize]
    public class FaktureController : Controller
    {
        private readonly IFakturaData db;
        private readonly FaktureProjectDbContext data = new FaktureProjectDbContext();

        public FaktureController(IFakturaData db)
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
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faktura faktura)
        {
            var vecPostoji = data.Fakture.Any(x => x.BrojFakture == faktura.BrojFakture);
            if (vecPostoji)
            {
                ModelState.AddModelError("BrojFakture", "Taj Broj Fakture vec postoji");
            }
            if (ModelState.IsValid)
            {
                faktura.DatumStvaranjaFakture = DateTime.Today;
                faktura.Korisnik = User.Identity.GetUserName();
                db.Add(faktura);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faktura faktura)
        {
            if (ModelState.IsValid)
            {
                db.Update(faktura);
                return RedirectToAction("Index");
            }
            return View(faktura);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Models;

namespace GestionScolaire.Controllers
{
    public class Academie : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Academie/

        public ActionResult Index()
        {
            return View(db.Academies.ToList());
        }

        //
        // GET: /Academie/Details/5

        public ActionResult Details(Guid id )
        {
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        //
        // GET: /GestionDesClasses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GestionDesClasses/Create

        [HttpPost]
        public ActionResult Create(Academies academies)
        {
            if (ModelState.IsValid)
            {
                academies.Id = Guid.NewGuid();
                db.Academies.Add(academies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academies);
        }

        //
        // GET: /GestionDesClasses/Edit/5

        public ActionResult Edit(Guid id )
        {
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        //
        // POST: /GestionDesClasses/Edit/5

        [HttpPost]
        public ActionResult Edit(Academies academies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academies);
        }

        //
        // GET: /GestionDesClasses/Delete/5

        public ActionResult Delete(Guid id )
        {
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        //
        // POST: /GestionDesClasses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Academies academies = db.Academies.Find(id);
            db.Academies.Remove(academies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
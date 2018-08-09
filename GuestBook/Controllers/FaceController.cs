using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuestBook.DAL;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class FaceController : Controller
    {
        private GuestBookContext db = new GuestBookContext();

        // GET: Face
        public ActionResult Index()
        {
            return View(db.Faces.ToList());
        }

        // GET: Face/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            return View(face);
        }

        // GET: Face/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Face/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Face face)
        {
            if (ModelState.IsValid)
            {
                db.Faces.Add(face);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(face);
        }

        // GET: Face/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            return View(face);
        }

        // POST: Face/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Face face)
        {
            if (ModelState.IsValid)
            {
                db.Entry(face).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(face);
        }

        // GET: Face/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Face face = db.Faces.Find(id);
            if (face == null)
            {
                return HttpNotFound();
            }
            return View(face);
        }

        // POST: Face/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Face face = db.Faces.Find(id);
            db.Faces.Remove(face);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

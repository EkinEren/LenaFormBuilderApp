using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormBuilder.DAL;
using FormBuilder.Models;

namespace FormBuilder.Controllers
{
    public class CustomFormController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        // GET: CustomForm
        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }

        // GET: CustomForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomForm customForm = db.Forms.Find(id);
            if (customForm == null)
            {
                return HttpNotFound();
            }
            return View(customForm);
        }

        // GET: CustomForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormId,Name,Description,CreatedAt")] CustomForm customForm)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(customForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customForm);
        }

        // GET: CustomForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomForm customForm = db.Forms.Find(id);
            if (customForm == null)
            {
                return HttpNotFound();
            }
            return View(customForm);
        }

        // POST: CustomForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormId,Name,Description,CreatedAt")] CustomForm customForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customForm);
        }

        // GET: CustomForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomForm customForm = db.Forms.Find(id);
            if (customForm == null)
            {
                return HttpNotFound();
            }
            return View(customForm);
        }

        // POST: CustomForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomForm customForm = db.Forms.Find(id);
            db.Forms.Remove(customForm);
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

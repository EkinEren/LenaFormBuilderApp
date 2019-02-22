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
    public class FormItemController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        // GET: FormItem
        public ActionResult Index()
        {
            return View(db.FormItems.ToList());
        }

        // GET: FormItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormItem formItem = db.FormItems.Find(id);
            if (formItem == null)
            {
                return HttpNotFound();
            }
            return View(formItem);
        }

        // GET: FormItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormItemID,Name,Required,DataType")] FormItem formItem)
        {
            if (ModelState.IsValid)
            {
                db.FormItems.Add(formItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formItem);
        }

        // GET: FormItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormItem formItem = db.FormItems.Find(id);
            if (formItem == null)
            {
                return HttpNotFound();
            }
            return View(formItem);
        }

        // POST: FormItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormItemID,Name,Required,DataType")] FormItem formItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formItem);
        }

        // GET: FormItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormItem formItem = db.FormItems.Find(id);
            if (formItem == null)
            {
                return HttpNotFound();
            }
            return View(formItem);
        }

        // POST: FormItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormItem formItem = db.FormItems.Find(id);
            db.FormItems.Remove(formItem);
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

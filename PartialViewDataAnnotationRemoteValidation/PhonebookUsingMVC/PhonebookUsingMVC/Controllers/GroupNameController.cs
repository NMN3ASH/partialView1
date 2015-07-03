using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhonebookUsingMVC.Models;

namespace PhonebookUsingMVC.Controllers
{
    public class GroupNameController : Controller
    {
        private Entities db = new Entities();

        // GET: /GroupName/
        public ActionResult Index()
        {
            return View(db.GroupNames.ToList());
        }

        // GET: /GroupName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupName groupname = db.GroupNames.Find(id);
            if (groupname == null)
            {
                return HttpNotFound();
            }
            return View(groupname);
        }

        // GET: /GroupName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GroupName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GroupNameId,Name")] GroupName groupname)
        {
            if (ModelState.IsValid)
            {
                db.GroupNames.Add(groupname);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupname);
        }

        // GET: /GroupName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupName groupname = db.GroupNames.Find(id);
            if (groupname == null)
            {
                return HttpNotFound();
            }
            return View(groupname);
        }

        // POST: /GroupName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GroupNameId,Name")] GroupName groupname)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupname).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupname);
        }

        // GET: /GroupName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupName groupname = db.GroupNames.Find(id);
            if (groupname == null)
            {
                return HttpNotFound();
            }
            return View(groupname);
        }

        // POST: /GroupName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupName groupname = db.GroupNames.Find(id);
            db.GroupNames.Remove(groupname);
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

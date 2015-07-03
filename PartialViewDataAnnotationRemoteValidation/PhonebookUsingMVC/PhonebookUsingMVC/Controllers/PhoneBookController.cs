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
    public class PhoneBookController : Controller
    {
        private Entities db = new Entities();

        // GET: /PhoneBook/
        public ActionResult Index()
        {
            var phonebooks = db.PhoneBooks.Include(p => p.GroupName);

            return View(db.PhoneBooks.ToList());
        }

        // GET: /PhoneBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }


        public JsonResult IsNumberExist(string number)
        {
            var phonebook = db.PhoneBooks.Where(m => m.Number == number).FirstOrDefault();
            if (phonebook != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: /PhoneBook/Create
        public ActionResult CreateNewPerson()
        {
            ViewBag.CreatePerson = new SelectList(db.GroupNames, "GroupNameId", "Name");
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewPerson([Bind(Include = "PhoneBookId,Number,FirstName,LastName,Email,Address,GroupNameId")] PhoneBook phonebook)
        {
            if (ModelState.IsValid)
            {
               
                phonebook.DateEntry = DateTime.Now;
                db.PhoneBooks.Add(phonebook);
                db.SaveChanges();
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Enter valid input...";

            }
            ViewBag.GroupNameId = new SelectList(db.GroupNames, "GroupNameId", "Name", phonebook.GroupNameId);
            return RedirectToAction("Index");
        }

        // GET: /PhoneBook/Edit/5
        public ActionResult EditPerson(int? id)
        {
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            ViewBag.GroupNameId = new SelectList(db.GroupNames, "GroupNameId", "Name", phonebook.GroupNameId);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: /PhoneBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson([Bind(Include = "PhoneBookId,Number,FirstName,LastName,Email,Address,GroupNameId,DateEntry")] PhoneBook phonebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupNameId = new SelectList(db.GroupNames, "GroupNameId", "Name", phonebook.GroupNameId);
            return View(phonebook);
        }


       

        // GET: /PhoneBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: /PhoneBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            db.PhoneBooks.Remove(phonebook);
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

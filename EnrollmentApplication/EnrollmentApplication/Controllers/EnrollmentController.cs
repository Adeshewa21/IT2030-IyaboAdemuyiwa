using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnrollmentApplication.Models;

namespace EnrollmentApplication.Controllers
{
    public class EnrollmentController : Controller
    {
        private EnrollmentDB db = new EnrollmentDB();

        // GET: StoreManager
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Student).Include(e => e.Course);
            return View(enrollments.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,CourseId,StudentId,Grade,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", enrollment.CourseId);
            return View(enrollment);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,CourseId,StudentId,Grade,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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
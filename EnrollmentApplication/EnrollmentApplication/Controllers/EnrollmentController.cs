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

        public object Enrollments { get; private set; }

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(a => a.Course).Include(a => a.Student);
            return View(db.Enrollments.ToList());
        }

        // GET: Enrollment/Details/5
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

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", "CourseCredits");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", "FirstName");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,StudentId,CourseId,Grade,StudentObject,CourseObject,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", "CourseCredits", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
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
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", "CourseCredits", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,StudentId,CourseId,Grade,StudentObject,CourseObject,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Coursetitle", "CourseCredits", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", "FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
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

        // POST: Enrollment/Delete/5
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



        public ActionResult Linq()
        {
            //1. Returns all enrollments

            var enrollments = db.Enrollments;
            if (enrollments == null)
            {
                return HttpNotFound();
            }


            // 2. Returns enrollments by a specific student
            var enrollmentsbystudent = (from a in enrollments
                                  where a.Student.LastName == "Kirbach"
                                  select a);

            // 3. Returns enrollments in a specific course
            var enrollmentsbycourse = (from a in enrollments
                                 where a.Course.CourseCredits == "4.00"
                                 orderby a.Grade descending
                                 select a);

            //4. Returns enrollment by name
            var enrollmentsbyname = (from a in enrollments
                                where a.AssignedCampus =="Western"
                                select a);

            // 5. Returns specific album by Id - use find() to identify a record by primary key
            //var albumById = db.lbums.Find(4);

            ViewBag.EnrollmentsByName = new SelectList(enrollmentsbyname, "EnrollmentId", "AssignedCampus", enrollments.First().EnrollmentId);
            ViewBag.EnrollmentsByCourse = new SelectList(enrollmentsbycourse, "EnrollmentId", "CourseCredits", enrollments.First().EnrollmentId);
            ViewBag.EnrollmentsByStudent = new SelectList(enrollmentsbystudent, "EnrollmentId", "LastName", enrollments.First().EnrollmentId);
            return View();
        }

        public ActionResult LinqExtension()
        {
            var EnrollmentsByName = db.Enrollments.Where(x => x.AssignedCampus == "Stormbringer");
            var EnrollmentsByCourse = db.Enrollments.Where(x => x.Course.CourseCredits == "4.00").OrderByDescending(x => x.Grade);
            var EnrollmentByStudent = db.Enrollments.Where(x => x.Student.LastName == "Kirbach");

            ViewBag.EnrollmentsByName = new SelectList(EnrollmentsByName, "EnrollmentId", "AssignedCampus", EnrollmentsByName.First().EnrollmentId);
            ViewBag.EnrollmentsByCourse = new SelectList(EnrollmentsByCourse, "EnrollmentId", "CourseCredits", EnrollmentsByCourse.First().EnrollmentId);
            ViewBag.EnrollmentsByStudent = new SelectList(EnrollmentByStudent, "EnrollmentId", "LastName", EnrollmentByStudent.First().EnrollmentId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", db.Students.First().StudentId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCredits", db.Courses.First().CourseId);

            return View();
        }

        public ActionResult Test()
        {
            var enrollments = db.Enrollments;
            // This format is LINQ Extensions
            var enrollmentsbyname = enrollments.Where(x => x.AssignedCampus == "Western");
            var enrollmentsbystudent = enrollments.Where(x => x.Student.LastName == "Kirbach");
            var enrollmentsbycourse = enrollments.Where(x => x.Course.CourseCredits == "4.00").OrderByDescending(x => x.Grade);
            


            // This format is LINQ It can also be written in this format below 
           /*
            var enrollmentsbyname = (from a in enrollments
                                where a.AssignedCampus == "Western"
                                select a);

            var enrollmentsbystudent = (from a in enrollments
                                 where a.Student.LastName == "Kirbach"
                                 select a);
            var enrollmentsbycourse = (from a in enrollments
                                 where a.Course.CourseCredits == "4.00"
                                 orderby a.Grade descending
                                 select a);
                                 */
            

            ViewBag.EnrollmentsByName = new SelectList(enrollmentsbyname, "EnrollmentId", "AssignedCampus", enrollmentsbyname.First().EnrollmentId);
            ViewBag.EnrollmentsByStudent = new SelectList(enrollmentsbystudent, "EnrollmentId", "LastName", enrollmentsbystudent.First().EnrollmentId);
            ViewBag.EnrollmentsByCourse = new SelectList(enrollmentsbycourse, "EnrollmentId", "CourseCredits", enrollmentsbycourse.First().EnrollmentId);
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T2004E_Test.Context;
using T2004E_Test.Models;
using System.IO;

namespace T2004E_Test.Controllers
{
    public class ExamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Exam
        public ActionResult Index(string subjectId,string classroomId,string facultiesId,string statusesId)
        {
            ViewBag.SubjectID = 0;
            var subjects = from p in db.Subjects select p;
            if (!String.IsNullOrEmpty(subjectId))
            {
                var sjId = Convert.ToInt32(subjectId);
                subjects = subjects.Where(p => p.SubjectID == sjId);
                ViewBag.SubjectId = sjId;
            }
            ViewBag.ClassRoomID = 0;
            var classrooms = from c in db.ClassRooms select c;
            if (!String.IsNullOrEmpty(classroomId))
            {
                var clId = Convert.ToInt32(classrooms);
                classrooms = classrooms.Where(p => p.ClassRoomID == clId);
                ViewBag.ClassRoomId = clId;
            }
            ViewBag.FacultiesID = 0;
            var faculties = from f in db.Faculties select f;
            if (!String.IsNullOrEmpty(facultiesId))
            {
                var fId = Convert.ToInt32(facultiesId);
                faculties =faculties.Where(p => p.FacultiesID == fId);
                ViewBag.FacultyId = fId;
            }
            ViewBag.StatusID = 0;
            var statuses = from s in db.Statuses select s;
            if (!String.IsNullOrEmpty(statusesId))
            {
                var sId = Convert.ToInt32(statusesId);
                statuses = statuses.Where(s=> s.StatusID == sId);
                ViewBag.StatusId = sId;
            }
            var exams = db.Exams.ToList();
            dynamic data = new ExpandoObject();
            data.Exams = exams;
            data.ClassRooms = classrooms;
            data.Faculties = faculties;
            data.Statuses = statuses;
            return View(data);
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,ExamDate,ExamDuration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,ExamDate,ExamDuration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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

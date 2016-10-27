using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIMS.Data;

namespace AIMS.Controllers
{
    public class SurveyGroupsController : Controller
    {
        private AIMSDbContext db = new AIMSDbContext();

        // GET: SurveyGroups
        public ActionResult Index()
        {
            var surveyGroups = db.SurveyGroups.Include(s => s.Group).Include(s => s.Survey);
            return View(surveyGroups.ToList());
        }

        // GET: SurveyGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyGroup surveyGroup = db.SurveyGroups.Find(id);
            if (surveyGroup == null)
            {
                return HttpNotFound();
            }
            return View(surveyGroup);
        }

        // GET: SurveyGroups/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name");
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name");
            return View();
        }

        // POST: SurveyGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyId,GroupId,LastSent,CreatedAt,UpdatedAt")] SurveyGroup surveyGroup)
        {
            if (ModelState.IsValid)
            {
                db.SurveyGroups.Add(surveyGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", surveyGroup.GroupId);
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyGroup.SurveyId);
            return View(surveyGroup);
        }

        // GET: SurveyGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyGroup surveyGroup = db.SurveyGroups.Find(id);
            if (surveyGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", surveyGroup.GroupId);
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyGroup.SurveyId);
            return View(surveyGroup);
        }

        // POST: SurveyGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyId,GroupId,LastSent,CreatedAt,UpdatedAt")] SurveyGroup surveyGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", surveyGroup.GroupId);
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyGroup.SurveyId);
            return View(surveyGroup);
        }

        // GET: SurveyGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyGroup surveyGroup = db.SurveyGroups.Find(id);
            if (surveyGroup == null)
            {
                return HttpNotFound();
            }
            return View(surveyGroup);
        }

        // POST: SurveyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyGroup surveyGroup = db.SurveyGroups.Find(id);
            db.SurveyGroups.Remove(surveyGroup);
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

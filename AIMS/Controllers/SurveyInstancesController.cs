using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIMS.Data;
using AIMS.Services;
using AIMS.Models;

namespace AIMS.Controllers
{
    public class SurveyInstancesController : Controller
    {
        private AIMSDbContext db = new AIMSDbContext();
        private readonly Lazy<SurveyService> _surveySvc = new Lazy<SurveyService>();

        /// <summary>
        /// GET: SurveyInstance/Report
        /// </summary>
        /// <param name="surveyId">The Survey Id to get the results for</param>
        /// <returns></returns>
        public ActionResult Report(int surveyId)
        {
            if (surveyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SurveyName = _surveySvc.Value.GetSurvey(surveyId).Name;

            return View(db.SurveyInstances.Where(s => s.SurveyId == surveyId).ToList());
        }

        // GET: SurveyInstances/Details/5
        public ActionResult Details(int? surveyInstanceId)
        {
            if (surveyInstanceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SurveyInstance surveyInstance = db.SurveyInstances.Find(surveyInstanceId);
            if (surveyInstance == null)
            {
                return HttpNotFound();
            }

            SurveyReportAnswerDetailVM surveyReportAnswerDetailVM = new SurveyReportAnswerDetailVM(surveyInstance);

            ViewBag.SurveyName = _surveySvc.Value.GetSurvey(surveyInstance.SurveyId).Name;

            return View(surveyReportAnswerDetailVM);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        // not yet implemented 
        ///////////////////////////////////////////////////////////////////////////////////////////

        //// GET: SurveyInstances
        //public ActionResult Index()
        //{
        //    return View(db.SurveyInstances.ToList());
        //}

        //// GET: SurveyInstances/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SurveyInstances/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "SurveyInstanceId,SurveyId,UserId,IsCompleted,CreatedAt,UpdatedAt")] SurveyInstance surveyInstance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SurveyInstances.Add(surveyInstance);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(surveyInstance);
        //}

        //// GET: SurveyInstances/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurveyInstance surveyInstance = db.SurveyInstances.Find(id);
        //    if (surveyInstance == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveyInstance);
        //}

        //// POST: SurveyInstances/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "SurveyInstanceId,SurveyId,UserId,IsCompleted,CreatedAt,UpdatedAt")] SurveyInstance surveyInstance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(surveyInstance).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(surveyInstance);
        //}

        //// GET: SurveyInstances/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurveyInstance surveyInstance = db.SurveyInstances.Find(id);
        //    if (surveyInstance == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveyInstance);
        //}

        //// POST: SurveyInstances/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SurveyInstance surveyInstance = db.SurveyInstances.Find(id);
        //    db.SurveyInstances.Remove(surveyInstance);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

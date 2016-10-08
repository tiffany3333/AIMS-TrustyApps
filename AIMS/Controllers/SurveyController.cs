using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIMS.Data;
using AIMS.Models;
using AIMS.Services;

namespace AIMS.Controllers
{
    public class SurveyController : BaseController
    {
        private readonly Lazy<SurveyService> _surveySvc = new Lazy<SurveyService>();

        //// GET: Survey
        public ActionResult Index()
        {
            SurveyViewModel mySurveys = new SurveyViewModel();

            return View(mySurveys);
            //return View(db.SurveyViewModels.ToList());
        }

        //// GET: Survey/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurveyViewModel surveyViewModel = db.SurveyViewModels.Find(id);
        //    if (surveyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveyViewModel);
        //}

        // GET: Survey/Create
        public ActionResult Create()
        {
            //TODO Cannot create survey unless you're an admin user
            return View();
        }

        // POST: Survey/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string surveyName, string[] dynamicQuestion, int[] repsoneNum, string[] dynamicResponse)
        {
            //TODO Cannot create survey unless you're an admin user

            int surveyId = _surveySvc.Value.CreateSurvey(surveyName);

            //TODO now that the survey has been created, tie it to the user's group via the survey_groups

            int count = 0;
            for (int i = 0; i < dynamicQuestion.Length; i++)
            {
                int k = 0;
                int questionId = _surveySvc.Value.CreateQuestion(surveyId, dynamicQuestion[i]);
                while (k < repsoneNum[i])
                {
                    _surveySvc.Value.CreateResponse(questionId, dynamicResponse[count]);
                    count++;
                    k++;
                }
            }

                       
            return RedirectToAction("../Survey/Index");
        }

        //// GET: Survey/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurveyViewModel surveyViewModel = db.SurveyViewModels.Find(id);
        //    if (surveyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveyViewModel);
        //}

        //// POST: Survey/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,IsDeactivated,CreatedAt,UpdatedAt")] SurveyViewModel surveyViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(surveyViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(surveyViewModel);
        //}

        //// GET: Survey/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SurveyViewModel surveyViewModel = db.SurveyViewModels.Find(id);
        //    if (surveyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(surveyViewModel);
        //}

        //// POST: Survey/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SurveyViewModel surveyViewModel = db.SurveyViewModels.Find(id);
        //    db.SurveyViewModels.Remove(surveyViewModel);
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

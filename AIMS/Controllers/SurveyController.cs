using AIMS.Models;
using AIMS.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using AIMS.Data;
using System.Web;
using System.IO;

namespace AIMS.Controllers
{
    public class SurveyController : BaseController
    {
        private readonly Lazy<SurveyService> _surveySvc = new Lazy<SurveyService>();
        private readonly Lazy<UserService> _usrSvc = new Lazy<UserService>();

        //// GET: Survey
        public ActionResult Index()
        {
            List<SurveyViewModel> mySurveys = _surveySvc.Value.GetSurveys();

            return View(mySurveys);
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            //TODO Cannot create survey unless you're an admin user
            return View();
        }

        // POST: Survey/Create
        //
        // This method creates the survey
        // There are currently 2 types of questions, multiple choice and paragraph.  
        // Paragraph question have a default value of "paragraph" hardcoded in their dynamicResponse field

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string surveyName, string[] dynamicQuestion, int[] repsoneNum, string[] dynamicResponse, int[] dynamicResponseValue, HttpPostedFileBase[] dynamicResponseImage)
        {
            //TODO Cannot create survey unless you're an admin user

            int surveyId = _surveySvc.Value.CreateSurvey(surveyName);

            //TODO now that the survey has been created, tie it to the user's group via the survey_groups

            int responseArrayCount = 0;
            int responseImageArrayCount = 0;

            for (int questionNum = 0; questionNum < dynamicQuestion.Length; questionNum++)
            {
                int responseNum = 0;
                int questionId = _surveySvc.Value.CreateQuestion(surveyId, dynamicQuestion[questionNum]);
                while (responseNum < repsoneNum[questionNum])
                {
                    HttpPostedFileBase responseImage = null;

                    if ( (!dynamicResponse[responseArrayCount].Equals("paragraph")) && (dynamicResponseImage != null))
                    {
                        if (dynamicResponseImage[responseImageArrayCount] != null)
                        {
                            responseImage = dynamicResponseImage[responseImageArrayCount];
                        }
                        responseImageArrayCount++;
                    }

                    _surveySvc.Value.CreateResponse(questionId, dynamicResponse[responseArrayCount], dynamicResponseValue[responseArrayCount], responseImage);

                    responseArrayCount++;
                    responseNum++;
                }
            }
       
            return RedirectToAction("../Survey/Index");
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int surveyId)
        {
            SurveyViewModel surveyViewModel = _surveySvc.Value.CreateSurveyVM(surveyId);

            if (surveyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyViewModel);
        }

        // POST: Survey/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsDeactivated")] SurveyViewModel surveyViewModel)
        {
            if (ModelState.IsValid)
            {
                bool success = _surveySvc.Value.EditSurvey(surveyViewModel);
                
                return RedirectToAction("Index");
            }
            return View(surveyViewModel);
        }

        //// GET: Survey/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyViewModel surveyViewModel = _surveySvc.Value.GetSurvey(id);
            if (surveyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(surveyViewModel);
        }

        //// GET: Survey/Assign
        public ActionResult Assign(int surveyId)
        {
            if (surveyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyViewModel surveyViewModel = _surveySvc.Value.GetSurvey(surveyId);
            List<AssignUserViewModel> assignUserVMs = _surveySvc.Value.GetUsersAssignments(surveyId);
            ViewBag.surveyId = surveyId;
            ViewBag.surveyName = surveyViewModel.Name;
            
            if (surveyViewModel == null || assignUserVMs == null)
            {
                return HttpNotFound();
            }
            return View(assignUserVMs);
        }

        public ActionResult AssignPost(int surveyID, List<int> userIDListAssign, List<int> userIDListUnAssign)
        {
            if (ModelState.IsValid)
            {
                _surveySvc.Value.AssignSurvey(surveyID, userIDListAssign, userIDListUnAssign);
                
                return RedirectToAction("/../Survey/Index");
            }
            return View();
    }

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

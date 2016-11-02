using System;
using System.Web.Mvc;
using AIMS.Models;
using AIMS.Services;
using System.Collections.Generic;
using System.Net;

namespace AIMS.Controllers
{
    public class GroupController : Controller
    {
        private readonly Lazy<GroupService> _groupSvc = new Lazy<GroupService>();
        private readonly Lazy<OrganizationService> _orgSvc = new Lazy<OrganizationService>();

        // GET: Groups (all in a certain org)
        public ActionResult Index(int? organizationId)
        {
            // organizationId = -1 means show all groups
            //TODO make that a constant so it's obvious
            List<GroupViewModel> myGroups = _groupSvc.Value.GetGroups(organizationId);
            return View(myGroups);
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupViewModel groupViewModel = _groupSvc.Value.GetGroup(id);
            if (groupViewModel == null)
            {
                return HttpNotFound();
            }
            return View(groupViewModel);
        }

        // GET: Group/Create
        public ActionResult Create(int organizationId)
        {
            //TODO Cannot create org unless you're an admin user

            ViewBag.OrganizationId = organizationId;
            ViewBag.OrganizationName = _orgSvc.Value.GetOrganizationName(organizationId);
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,Name")] GroupViewModel groupViewModel)
        {
            int? groupId = _groupSvc.Value.CreateGroup(groupViewModel.OrganizationId, groupViewModel.Name);

            return RedirectToAction("../Organization/Details/" + groupViewModel.OrganizationId);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            GroupViewModel groupViewModel = _groupSvc.Value.CreateGroupVM(id);
            if (groupViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationName = _orgSvc.Value.GetOrganizationName(groupViewModel.OrganizationId);

            return View(groupViewModel);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,OrganizationId,Name,CreatedAt,UpdatedAt")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                bool success = _groupSvc.Value.EditGroup(groupViewModel);

                return RedirectToAction("../Organization/Details/" + groupViewModel.OrganizationId);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GroupViewModel groupViewModel = _groupSvc.Value.GetGroup(id);
            ViewBag.OrganizationName = _orgSvc.Value.GetOrganizationName(groupViewModel.OrganizationId);

            if (groupViewModel == null)
            {
                return HttpNotFound();
            }
            return View(groupViewModel);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupViewModel groupViewModel = _groupSvc.Value.GetGroup(id);

            bool success = _groupSvc.Value.DeleteGroup(id);

            return RedirectToAction("../Organization/Details/" + groupViewModel.OrganizationId);
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}

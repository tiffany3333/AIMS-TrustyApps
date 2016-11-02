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

        // GET: Groups (all in a certain org)
        public ActionResult Index(int? organizationId)
        {
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
        public ActionResult Create(int? organizationId)
        {
            //TODO Cannot create org unless you're an admin user

            ViewBag.OrganizationId = organizationId;
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

            return RedirectToAction("../Group/Index");
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupViewModel groupViewModel = _groupSvc.Value.CreateGroupVM(id);
            if (groupViewModel == null)
            {
                return HttpNotFound();
            }
            
            return View(groupViewModel);
        }

        //    // POST: Group/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "GroupId,OrganizationId,Name,CreatedAt,UpdatedAt")] Group group)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(group).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.GroupId = new SelectList(db.Entities, "Id", "Id", group.GroupId);
        //        ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", group.OrganizationId);
        //        return View(group);
        //    }

        //    // GET: Group/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Group group = db.Groups.Find(id);
        //        if (group == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(group);
        //    }

        //    // POST: Group/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Group group = db.Groups.Find(id);
        //        db.Groups.Remove(group);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

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

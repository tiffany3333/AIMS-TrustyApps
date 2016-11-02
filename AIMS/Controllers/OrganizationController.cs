using System;
 using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using AIMS.Models;
using AIMS.Services;

namespace AIMS.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly Lazy<OrganizationService> _organizationSvc = new Lazy<OrganizationService>();

        // GET: Organizations
        public ActionResult Index()
        {
            List<OrganizationViewModel> myOrganizations = _organizationSvc.Value.GetOrganizations();
            
            return View(myOrganizations);
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationViewModel organizationViewModel = _organizationSvc.Value.GetOrganization(id);
            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(organizationViewModel);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            //TODO Cannot create org unless you're an admin user
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Address,City,State,ZipCode,PhoneNumber")] OrganizationViewModel organizationViewModel)
        {
            //TODO Cannot create org unless you're an admin user

            int organizationId = _organizationSvc.Value.CreateOrganization(organizationViewModel.Name, organizationViewModel.Description, organizationViewModel.Address, organizationViewModel.City, organizationViewModel.State, organizationViewModel.ZipCode, organizationViewModel.PhoneNumber);
            
            return RedirectToAction("../Organization/Index");
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int organizationId)
        {
            OrganizationViewModel organizationViewModel = _organizationSvc.Value.CreateOrganizationVM(organizationId);
            
            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }

            return View(organizationViewModel);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,Name,Description,Address,City,State,ZipCode,PhoneNumber,CreatedAt,UpdatedAt")] OrganizationViewModel organizationViewModel)
        {
            //TODO cannot edit org unless you're an admin user
            bool success = _organizationSvc.Value.EditOrganization(organizationViewModel);
            
            return RedirectToAction("Index");
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? organizationId)
        {
            if (organizationId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationViewModel organizationViewModel = _organizationSvc.Value.GetOrganization(organizationId);
            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(organizationViewModel);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? organizationId)
        {
            bool success = _organizationSvc.Value.DeleteOrganization(organizationId);
            return RedirectToAction("Index");
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

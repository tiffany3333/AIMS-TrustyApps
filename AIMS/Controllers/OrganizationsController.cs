using System;
 using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AIMS.Models;
using AIMS.Services;

namespace AIMS.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly Lazy<OrganizationService> _organizationSvc = new Lazy<OrganizationService>();

        // GET: Organizations
        public ActionResult Index()
        {
            //var organizations = db.Organizations.Include(o => o.Entity);
            OrganizationViewModel myOrganizations = new OrganizationViewModel();
            //return View(organizations.ToList());
            return View(myOrganizations);
        }

        //// GET: Organizations/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrganizationViewModel organizationViewModel = db.OrganizationsViewModels.Find(id);
        //    if (organizationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(organizationViewModel);
        //}

        // GET: Organizations/Create
        public ActionResult Create()
        {
            //ViewBag.OrganizationId = new SelectList(db.Entities, "Id", "Id");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] OrganizationViewModel organizationViewModel)
        {
            int organizationId = _organizationSvc.Value.CreateOrganization(organizationViewModel.Name, organizationViewModel.Description);

            return RedirectToAction("../Organization/Index");
        }

        // GET: Organizations/Edit/5
        //public ActionResult Edit(int? organizationId)
        //{
        //    if (organizationId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrganizationViewModel organizationViewModel =   new OrganizationViewModel(organizationId);
        //    db.OrganizationsViewModel.Find(organizationId);
        //    if (organizationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(organizationViewModel);
        //}

        //// POST: Organizations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrganizationId,Name,Description,CreatedAt,UpdatedAt")] OrganizationViewModel organizationViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(organizationViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(organizationViewModel);
        //}

        //// GET: Organizations/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrganizationViewModel organizationViewModel = db.OrganizationsViewModel.Find(id);
        //    if (organizationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(organizationViewModel);
        //}

        //// POST: Organizations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    OrganizationViewModel organizationViewModel = db.OrganizationsViewModel.Find(id);
        //    db.Organizations.Remove(organizationViewModel);
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

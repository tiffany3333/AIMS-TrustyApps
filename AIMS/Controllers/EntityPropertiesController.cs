using System;
using System.Web.Mvc;
using AIMS.Services;
using Microsoft.AspNet.Identity;
using AIMS.Models;

namespace AIMS.Controllers
{
    public class EntityPropertiesController : Controller
    {
        private readonly Lazy<UserService> _userSvc;
        private readonly Lazy<EntityPropertyService> _propSvc = new Lazy<EntityPropertyService>();

        public EntityPropertiesController()
        {
            _userSvc = new Lazy<UserService>(
                        () =>
                        {
                            var userName = User.Identity.GetUserName();
                            return new UserService(userName);
                        });
        }

        // GET: EntityProperties/Create
        public ActionResult Create(int entityId)
        {
            EntityPropertyViewModel propertyVM = new EntityPropertyViewModel(_userSvc.Value.GetUserVM(entityId));
            return View(propertyVM);
        }

        // POST: EntityProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EntityId,Title,Description,Link,ImageURL")]EntityPropertyViewModel entityPropertyVM)
        {
            if (ModelState.IsValid)
            {
                _propSvc.Value.CreateProperty(entityPropertyVM);
            }

            return RedirectToAction("../User/Details/", new { userId = entityPropertyVM.UserId });
        }

    //    // GET: EntityProperties
    //    public ActionResult Index()
    //    {
    //        var entityProperties = db.EntityProperties.Include(e => e.Entity).Include(e => e.PropertyDef);
    //        return View(entityProperties.ToList());
    //    }

    //    // GET: EntityProperties/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        EntityProperty entityProperty = db.EntityProperties.Find(id);
    //        if (entityProperty == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(entityProperty);
    //    }

        

    //    // GET: EntityProperties/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        EntityProperty entityProperty = db.EntityProperties.Find(id);
    //        if (entityProperty == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.EntityId = new SelectList(db.Entities, "Id", "Id", entityProperty.EntityId);
    //        ViewBag.PropertyDefId = new SelectList(db.PropertyDefs, "Id", "Name", entityProperty.PropertyDefId);
    //        return View(entityProperty);
    //    }

    //    // POST: EntityProperties/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "EntityId,PropertyDefId,Title,Description,Link,ImageURL,CreatedAt,UpdatedAt")] EntityProperty entityProperty)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(entityProperty).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.EntityId = new SelectList(db.Entities, "Id", "Id", entityProperty.EntityId);
    //        ViewBag.PropertyDefId = new SelectList(db.PropertyDefs, "Id", "Name", entityProperty.PropertyDefId);
    //        return View(entityProperty);
    //    }

    //    // GET: EntityProperties/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        EntityProperty entityProperty = db.EntityProperties.Find(id);
    //        if (entityProperty == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(entityProperty);
    //    }

    //    // POST: EntityProperties/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        EntityProperty entityProperty = db.EntityProperties.Find(id);
    //        db.EntityProperties.Remove(entityProperty);
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

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AIMS.Data;
using AIMS.Services;
using Microsoft.AspNet.Identity;
using System.Net;
using AIMS.Models;

namespace AIMS.Controllers
{
    public class UserController : Controller
    {
        private readonly Lazy<UserService> _userSvc;

        public UserController()
        {
            _userSvc = new Lazy<UserService>(
                        () =>
                        {
                            var userName = User.Identity.GetUserName();
                            return new UserService(userName);
                        });
        }

        // GET: User
        public ActionResult Index()
        {
            List<User> myUsers = _userSvc.Value.GetUsers();
            return View(myUsers);
        }

        // GET: User/Details/5
        public ActionResult Details(int userId)
        {
            if (userId == null)
            {
                return HttpNotFound();
            }

            ViewBag.Contacts = _userSvc.Value.GetContacts(userId);

            UserDetailsViewModel userVM = _userSvc.Value.GetUserVM(userId);

            return View(userVM);
        }

        //// GET: User/Edit/5
        //public ActionResult Edit(int? userId)
        //{
        //    if (userId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(userId);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.Entities, "Id", "Id", user.UserId);
        //    return View(user);
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserId = new SelectList(db.Entities, "Id", "Id");
        //    return View();
        //}

        //// POST: User/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,UserType,CreatedAt,UpdatedAt")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.User.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.Entities, "Id", "Id", user.UserId);
        //    return View(user);
        //}

        //// POST: User/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,UserType,CreatedAt,UpdatedAt")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.Entities, "Id", "Id", user.UserId);
        //    return View(user);
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.User.Find(id);
        //    db.User.Remove(user);
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

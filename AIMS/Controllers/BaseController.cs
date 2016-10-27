using System;
using System.Web.Mvc;
using AIMS.Services;
using Microsoft.AspNet.Identity;

namespace AIMS.Controllers
{
    public class BaseController : Controller
    {
        protected readonly Lazy<UserService> _userSvc;

        public BaseController()
        {
            _userSvc =
                   new Lazy<UserService>(
                       () =>
                       {
                           var userName = User.Identity.GetUserName();
                           return new UserService(userName);
                       });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pedal.Data;
using Pedal.Models;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;

namespace Pedal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                if (IsAdminUser())
                {
                    return View("AdminIndex");
                }
                return View();
            }
            else
            {
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = userManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
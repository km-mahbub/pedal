using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pedal.Data;
using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
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
            var stores = _unitOfWork.Stores.GetAll();

           
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;

                if (IsRole() == "Admin")
                {
                    return View("AdminIndex");
                }
                else if (IsRole() == "Manager")
                {
                    return RedirectToAction("Index", "Store");
                }
                else if (IsRole() == "Customer")
                {
                    return View("CustomerIndex");
                }
                return View(stores);
            }
            else
            {
                return View(stores);
            }
            
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

        public string IsRole()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = userManager.GetRoles(user.GetUserId());
                return s[0].ToString();
            }
            return "User not Logged In";
        }
    }
}
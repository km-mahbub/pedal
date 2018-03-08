using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;

namespace Pedal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var cycles = _unitOfWork.CycleRepository.GetAll();
            return View(cycles);
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
    }
}
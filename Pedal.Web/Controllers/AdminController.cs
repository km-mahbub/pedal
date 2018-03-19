using Pedal.Models;
using Pedal.Repositories.Interfaces;
using Pedal.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pedal.Web.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DailyStoreTransactionSummary()
        {
            // var stores = _unitOfWork.Stores.GetAll();
            var customers = _unitOfWork.UserManager.Users.ToList();
            var transections = _unitOfWork.CashMemos.GetDailyTransaction();
            var stores = _unitOfWork.Stores.GetAll();

            var cashViewModel = new CashMemoViewModel
            {
                Stores=stores,
                Customers=customers,
                Transections = transections
            };


            return View(cashViewModel);

        }




    }
}
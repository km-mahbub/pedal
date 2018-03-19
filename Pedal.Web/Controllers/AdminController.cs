using Pedal.Models;
using Pedal.Repositories.Interfaces;
using Pedal.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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


        public ActionResult DailyTransactionAdmin(int id)
        {
            var stores = _unitOfWork.Stores.GetAll();
            var customers = _unitOfWork.UserManager.Users.ToList();

            var transections =
                _unitOfWork.CashMemos.GetDailyTransectionByStore(id);


            var cycles = _unitOfWork.Cycles.GetAll();

            CashMemoViewModel myModel = new CashMemoViewModel
            {
                Stores = stores,
                Customers = customers,
                Transections = transections,
                Cycles = cycles
            };


            return View("DailyTransaction", myModel);
        }

        public ActionResult MostRentedStore()
        {
            var rents = _unitOfWork.Rents.GetDaliyRents();
            var customers = _unitOfWork.UserManager.Users.ToList();
            var stores = _unitOfWork.Stores.GetAll();

            var viewModel = new MostRentedStoreViewModel
            {
                Rents = rents,
                AppUsers = customers,
                Stores = stores
            };
            return View(viewModel);
        }


    }
}
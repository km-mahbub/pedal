using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pedal.Models;
using Pedal.Web.Helpers;
using Pedal.Web.Models.ViewModels;
using Pedal.Web.Helpers;

namespace Pedal.Web.Controllers
{
    public class ManagerController : Controller
    {

        IUnitOfWork _unitOfWork;
        public ManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: Manager
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = _unitOfWork.UserManager.Users.Where(b => b.UserType == "Manager").ToList();

            StoreViewModel viewModel = new StoreViewModel
            {
                Stores = _unitOfWork.Stores.GetStoresWithAddress(),
                AppUsers = users
            };

            
           
            return View(viewModel);
        }

        // GET: Manager/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            var user = _unitOfWork.UserManager.FindById(id);
            return View(user);
        }

        // POST: Manager/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Rent(int id)
        {
            var toBeRentedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            RentViewModel toBeRented = new RentViewModel
            {
                Cycle = toBeRentedCycle,
                ManagerId = User.Identity.GetUserId(),
                RentedFromStoreId = toBeRentedCycle.StoreId
            };


            return View(toBeRented);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Rent(int id, RentViewModel model)
        {
            var customer = _unitOfWork.UserManager.FindByName(model.CustomerName);
            var cycle = _unitOfWork.Cycles.Get(id);
            var store = _unitOfWork.Stores.Get(cycle.StoreId);
            Rent toBeRented = new Rent
            {
                CycleId = id,
                ManagerId = User.Identity.GetUserId(),
                RentedFromStoreId = store.StoreId,
                CustomerId = customer.Id,
                TrackId = TrackIdGenerotor.Generate(),
                RentedTime = DateTime.Now
            };

            cycle.CycleStatusType = CycleStatusType.Rented;
            store.TotalCycle -= 1;
            _unitOfWork.Rents.Add(toBeRented);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Store");

            return HttpNotFound();
        }

        //[HttpPost]
        //public ActionResult Booking(int id, Booking model)
        //{
        //    Cycle toBeBookedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
        //    Booking toBeBooked = new Booking
        //    {
        //        CycleId = id,
        //        BookingStatus = true,
        //        CustomerId = User.Identity.GetUserId(),
        //        BookingTime = DateTime.Now,
        //        StoreId = toBeBookedCycle.StoreId,
        //        BookingTrackId = this.BookinTrackIdGenerator(),
        //    };

        //    _unitOfWork.Bookings.Add(toBeBooked);
        //    toBeBookedCycle.CycleStatusType = CycleStatusType.Booked;
        //    _unitOfWork.Complete();


        //    return View("Index", _unitOfWork.Cycles.GetCycleByStoreId(toBeBookedCycle.StoreId));
        //}
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public bool FindCustomer(string value)
        {
            var user = _unitOfWork.UserManager.FindByName(value);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Bookings()
        {
            var manager = _unitOfWork.UserManager.FindById(User.Identity.GetUserId());
            return View(_unitOfWork.Bookings.GetBookedCycleByStoreId(manager.StoreId));
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult RentFromBooking(int id)
        {
            var booking = _unitOfWork.Bookings.Get(id);
            var customer = _unitOfWork.UserManager.FindById(booking.CustomerId);
            var manager = _unitOfWork.UserManager.FindById(User.Identity.GetUserId());
            var cycle = _unitOfWork.Cycles.GetCycleWithDetails(booking.CycleId);
            var store = _unitOfWork.Stores.Get(booking.StoreId);
            var rentTime = DateTime.Now;

            var viewModel = new BookingToRentViewModel
            {
                Customer = customer,
                Manager = manager,
                Cycle = cycle,
                Store = store,
                Booking = booking,
                RentedTime = rentTime
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult RentFromBooking(int id, BookingToRentViewModel viewModel)
        {
            var booking = _unitOfWork.Bookings.Get(id);
            var cycle = _unitOfWork.Cycles.Get(booking.CycleId);
            var store = _unitOfWork.Stores.Get(booking.StoreId);
            var rentTime = DateTime.Now;
            var rent = new Rent
            {
                CycleId = cycle.CycleId,
                RentedTime = rentTime,
                RentedFromStoreId = store.StoreId,
                ManagerId = User.Identity.GetUserId(),
                CustomerId = booking.CustomerId,
                TrackId = TrackIdGenerotor.Generate(),
                BookingId = booking.BookingId
            };
            _unitOfWork.Rents.Add(rent);

            booking.IsRented = true;
            cycle.CycleStatusType = CycleStatusType.Rented;
            store.TotalCycle -= 1;

            _unitOfWork.Complete();
            return RedirectToAction("Bookings");

        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult ReceiveCycle()
        {

            return View();

        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult ReceiveCycle(CashMemoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rent = _unitOfWork.Rents.GetRentByTrackId(model.TrackId);

                var cycle = _unitOfWork.Cycles.Get(rent.CycleId);

                var store = _unitOfWork.Stores.GetStoreWithManager(User.Identity.GetUserId());

                var rentedHour = TrackIdGenerotor.CalculateHour(rent.RentedTime);

                CashMemo memo = new CashMemo
                {
                    RentedHour = rentedHour,
                    TotalCost = TrackIdGenerotor.CalculateCost(rentedHour, (int)cycle.CostPerHour),
                    ManagerId = User.Identity.GetUserId(),
                    CustomerId = rent.CustomerId,
                    RentId = rent.RentId,
                    StoreId = _unitOfWork.Stores.GetStoreWithManager(User.Identity.GetUserId()).StoreId,
                    CashReceiveTime = DateTime.Now,
                };

                _unitOfWork.CashMemos.Add(memo);
                cycle.CycleStatusType = CycleStatusType.Available;
                cycle.RentedHour += rentedHour;
                cycle.StoreId = store.StoreId;

                rent.IsReceived = true;
                rent.ReturnTime = DateTime.Now;
                rent.ToBeSubmittedStoreId = store.StoreId;

                store.TotalCycle += 1;

                _unitOfWork.Complete();

                return RedirectToAction("Index", "Store");
            }
            


            return HttpNotFound();

        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult FindCycle(string value)
        {
            var rent = _unitOfWork.Rents.GetRentByTrackId(value);
            var cycle = _unitOfWork.Cycles.Get(rent.CycleId);
            var rentedHour = TrackIdGenerotor.CalculateHour(rent.RentedTime);

            var viewModel = new CashMemoViewModel
            {
                CustomerName = _unitOfWork.UserManager.FindById(rent.CustomerId).UserName,
                CycleName = _unitOfWork.Companies.Get(cycle.CompanyId).Name,
                RentedFromStoreName = _unitOfWork.Stores.Get(rent.RentedFromStoreId).Name,
                RentedHour = rentedHour,
                TotalCost = TrackIdGenerotor.CalculateCost(rentedHour, (int)cycle.CostPerHour)
            };

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult DailyTransaction()
        {
            var stores = _unitOfWork.Stores.GetAll();
            var customers = _unitOfWork.UserManager.Users.ToList();
            
            var transections =
                _unitOfWork.CashMemos.GetDailyTransectionByStore(_unitOfWork.Stores
                    .GetStoreWithManager(User.Identity.GetUserId()).StoreId);
            
            
            var cycles = _unitOfWork.Cycles.GetAll();

            CashMemoViewModel myModel = new CashMemoViewModel
            {
                Stores =  stores,
                Customers = customers,
                Transections = transections,
                Cycles = cycles
            };


            return View(myModel);

        }
    }
}

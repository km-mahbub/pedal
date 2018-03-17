using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
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

        public ActionResult Bookings()
        {
            var manager = _unitOfWork.UserManager.FindById(User.Identity.GetUserId());
            return View(_unitOfWork.Bookings.GetBookedCycleByStoreId(manager.StoreId));
        }

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
        [HttpGet]
        public ActionResult ReceiveCycle()
        {

            return View();

        }





    }
}

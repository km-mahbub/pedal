using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;
using Pedal.Models;

namespace Pedal.Web.Controllers
{
    public class CustomerController : Controller
    {

        IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
        [Authorize(Roles = "Customer")]
        public ActionResult CurrentBookings()
        {
            var userId = User.Identity.GetUserId();
            var bookings = _unitOfWork.Bookings.GetBookingsByCustomerId(userId);
            return View(bookings);
        }

        public ActionResult CancelBooking(int id)
        {
            var booking = _unitOfWork.Bookings.Get(id);
            var cycle = _unitOfWork.Cycles.Get(booking.CycleId);

            cycle.CycleStatusType = CycleStatusType.Available;

            booking.IsDeleted = true;
            booking.BookingStatus = false;
            _unitOfWork.Complete();
            return RedirectToAction("CurrentBookings");


        }
    }
}

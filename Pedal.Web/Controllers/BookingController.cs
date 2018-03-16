using Microsoft.AspNet.Identity;
using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pedal.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: Booking/Create
        public ActionResult Create(int id)
        {
            //Cycle toBeBookedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            //Booking toBeBooked = new Booking
            //{
            //    CycleId = id,
            //    Cycle = toBeBookedCycle,
            //    BookingStatus = true,
            //    CustomerId = User.Identity.GetUserId(),
            //    BookingTime = DateTime.Now,
            //    StoreId = toBeBookedCycle.StoreId,
            //    Store = _unitOfWork.Stores.Get(toBeBookedCycle.StoreId),
            //    BookingTrackId = this.BookinTrackIdGenerator(),
            //};
            

            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(int id, Booking model)
        {
            try
            {
                // TODO: Add insert logic here

                Console.WriteLine(model.CycleId);

                //Booking toBeBooked = new Booking
                //{
                //    CycleId = id,
                //    Cycle = toBeBookedCycle,
                //    BookingStatus = true,
                //    CustomerId = User.Identity.GetUserId(),
                //    BookingTime = DateTime.Now,
                //    StoreId = toBeBookedCycle.StoreId,
                //    Store = _unitOfWork.Stores.Get(toBeBookedCycle.StoreId),
                //    BookingTrackId = this.BookinTrackIdGenerator(),
                //};

                //_unitOfWork.Bookings.Add(model);
                //_unitOfWork.Complete();
                //var cycle = _unitOfWork.Cycles.Get(model.CycleId);
                //cycle.CycleStatusType = CycleStatusType.Booked;
                //_unitOfWork.Complete();

                return RedirectToAction("CycleStore", "Cycle", new { id = model.StoreId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
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

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
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
        
    }
}

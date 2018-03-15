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
            Cycle toBeBookedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            Booking toBeBooked = new Booking
            {
                CycleId = id,
                BookingStatus = true,
                CustomerId = User.Identity.GetUserId(),
                BookingTime = DateTime.Now,
                StoreId = toBeBookedCycle.StoreId,
                BookingTrackId = this.BookinTrackIdGenerator()
            };
            

            return View(toBeBooked);
        }

        // POST: Booking/Create
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
        private String BookinTrackIdGenerator()
        {
            const string arrr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            string str = "";
            int next;
            for (int i = 0; i < 5; i++)
            {
                next = rnd.Next(0, 35);
                str += arrr[next];

            }
            return str;

        }
    }
}

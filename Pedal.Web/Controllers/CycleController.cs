using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pedal.Web.Models.ViewModels;

namespace Pedal.Web.Controllers
{
    public class CycleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CycleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Cycle
        public ActionResult Index()
        {
            return View(_unitOfWork.Cycles.GetAllWithDetails());
        }

        public ActionResult CycleStore(int id)
        {
            return View("Index", _unitOfWork.Cycles.GetCycleByStoreId(id));
        }

        // GET: Cycle/Details/5
        public ActionResult Details(int id)
        {
            var cycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            if (cycle != null)
            {
                return View(cycle);
            }
            return HttpNotFound();

        }

        // GET: Cycle/Create
        public ActionResult Create()
        {
            CycleViewModel model = new CycleViewModel
            {
                CompanyList = new SelectList(_unitOfWork.Companies.GetAll(), "CompanyId", "Name"),
                StoreList = new SelectList(_unitOfWork.Stores.GetAll(), "StoreId", "Name")
            };

            return View(model);
        }

        // POST: Cycle/Create
        [HttpPost]
        public ActionResult Create(CycleViewModel cycle)
        {

            if (ModelState.IsValid)
            {
                Cycle cycleToAdd = new Cycle
                {
                    CycleStatusType = cycle.CycleStatusType,
                    CompanyId = cycle.CompanyId,
                    CycleType = cycle.CycleType,
                    StoreId = cycle.StoreId,
                    CostPerHour = cycle.CostPerHour
                };
                _unitOfWork.Cycles.Add(cycleToAdd);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return HttpNotFound();

        }

        // GET: Cycle/Edit/5
        public ActionResult Edit(int id)
        {
            var cycle = _unitOfWork.Cycles.Get(id);
            CycleViewModel viewModel = new CycleViewModel
            {
                CycleId = cycle.CycleId,
                CompanyId = cycle.CompanyId,
                CycleType = cycle.CycleType,
                StoreId = cycle.StoreId,
                CycleStatusType = cycle.CycleStatusType,
                CompanyList = new SelectList(_unitOfWork.Companies.GetAll(), "CompanyId", "Name"),
                StoreList = new SelectList(_unitOfWork.Stores.GetAll(), "StoreId", "Name"),
                CostPerHour = cycle.CostPerHour
            };

            return View(viewModel);
        }

        // POST: Cycle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CycleViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Cycle cycleToUpdate = _unitOfWork.Cycles.Get(id);
                    cycleToUpdate.CompanyId = model.CompanyId;
                    cycleToUpdate.StoreId = model.StoreId;
                    cycleToUpdate.CycleStatusType = model.CycleStatusType;
                    cycleToUpdate.CycleType = model.CycleType;
                    cycleToUpdate.CostPerHour = model.CostPerHour;

                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Cycle/Delete/5
        public ActionResult Delete(int id)
        {
            var cycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            if (cycle != null)
            {
                return View(cycle);
            }
            return HttpNotFound();
        }

        // POST: Cycle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cycle model)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var cycleToDelete = _unitOfWork.Cycles.Get(id);

                    cycleToDelete.IsDeleted = true;
                    _unitOfWork.Complete();


                    return RedirectToAction("Index");

                }

                return HttpNotFound();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Booking(int id)
        {
            Cycle toBeBookedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            Booking toBeBooked = new Booking
            {
                CycleId = id,
                Cycle = toBeBookedCycle,
                BookingStatus = true,
                CustomerId = User.Identity.GetUserId(),
                BookingTime = DateTime.Now,
                StoreId = toBeBookedCycle.StoreId,
                Store = _unitOfWork.Stores.Get(toBeBookedCycle.StoreId),
                BookingTrackId = this.BookinTrackIdGenerator(),
            };


            return View(toBeBooked);
        }

        [HttpPost]
        public ActionResult Booking(int id, Booking model)
        {
            Cycle toBeBookedCycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            Booking toBeBooked = new Booking
            {
                CycleId = id,
                BookingStatus = true,
                CustomerId = User.Identity.GetUserId(),
                BookingTime = DateTime.Now,
                StoreId = toBeBookedCycle.StoreId,
                BookingTrackId = this.BookinTrackIdGenerator(),
            };

            _unitOfWork.Bookings.Add(toBeBooked);
            toBeBookedCycle.CycleStatusType = CycleStatusType.Booked;
            _unitOfWork.Complete();


            return View("Index", _unitOfWork.Cycles.GetCycleByStoreId(toBeBookedCycle.StoreId));
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

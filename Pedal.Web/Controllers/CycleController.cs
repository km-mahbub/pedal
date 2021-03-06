﻿using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pedal.Web.Helpers;
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

        [Authorize(Roles = "Admin")]
        // GET: Cycle
        public ActionResult Index()
        {
            return View(_unitOfWork.Cycles.GetAllWithDetails());
        }

        public ActionResult CycleStore(int id)
        {
            ViewBag.StoreName = _unitOfWork.Stores.Get(id).Name;
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

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

                var store = _unitOfWork.Stores.Get(cycle.StoreId);
                store.TotalCycle += 1;

                _unitOfWork.Complete();



                return RedirectToAction("Index");
            }

            CycleViewModel model = new CycleViewModel
            {
                CompanyList = new SelectList(_unitOfWork.Companies.GetAll(), "CompanyId", "Name"),
                StoreList = new SelectList(_unitOfWork.Stores.GetAll(), "StoreId", "Name")
            };

            return View(model);

        }

        // GET: Cycle/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var cycle = _unitOfWork.Cycles.GetCycleWithDetails(id);
            
            if (cycle != null  && cycle.CycleStatusType == CycleStatusType.Available)
            {
                return View(cycle);
            }
            return HttpNotFound();
        }

        // POST: Cycle/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, Cycle model)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {



                    var cycleToDelete = _unitOfWork.Cycles.Get(id);
                    var store = _unitOfWork.Stores.Get(cycleToDelete.StoreId);
                    store.TotalCycle -= 1;
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

        [Authorize(Roles = "Customer")]
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
                Store = _unitOfWork.Stores.Get(toBeBookedCycle.StoreId)
            };


            return View(toBeBooked);
        }

        [Authorize(Roles = "Customer")]
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
                BookingTrackId = TrackIdGenerotor.Generate(),
                CycleName = toBeBookedCycle.Company.Name
            };

            _unitOfWork.Bookings.Add(toBeBooked);
            toBeBookedCycle.CycleStatusType = CycleStatusType.Booked;
            _unitOfWork.Complete();


            return View("Index", _unitOfWork.Cycles.GetCycleByStoreId(toBeBookedCycle.StoreId));
        }

        
    }
}

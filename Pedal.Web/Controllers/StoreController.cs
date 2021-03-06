﻿using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pedal.Models;
using Pedal.Web.Models.ViewModels;

namespace Pedal.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        // GET: Store
        public ActionResult Index()
        {
            

            if (User.IsInRole("Manager"))
            {
                var user = _unitOfWork.UserManager.FindById(User.Identity.GetUserId());
                if (user.StoreId != 0)
                {
                    ViewBag.StoreName = _unitOfWork.Stores.Get(user.StoreId).Name;
                    return View("ManagerIndex", _unitOfWork.Cycles.GetCycleForManager(user.StoreId));
                }

                return View("NoStoreView");

            }

            if (User.IsInRole("Admin"))
            {
                var stores = _unitOfWork.Stores.GetStoresWithAddress();

                return View(stores);
            }

            var storeList = _unitOfWork.Stores.GetStoresWithAddress().Where(b => b.ManagerId != null);

            return View(storeList);

        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var store = _unitOfWork.Stores.Get(id);
            var address = _unitOfWork.Addresses.Get(store.AddressId);

            StoreViewModel storeView = new StoreViewModel
            {
                StoreId = id,
                Name = store.Name,
                TotalCycle = store.TotalCycle,
                Lat = address.Lat,
                Lon = address.Lon,
                Area = address.Area,
                City = address.City,
                Country = address.Country
            };
            if (storeView != null)
            {
                return View(storeView);
            }

            return HttpNotFound();
        }

        // GET: Store/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var createStore = new StoreViewModel();
            return View(createStore);
        }


        // POST: Store/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Area = model.Area,
                    City = model.City,
                    Country = model.Country,
                    Lat = model.Lat,
                    Lon = model.Lon
                };
                _unitOfWork.Addresses.Add(address);
                _unitOfWork.Complete();


                var store = new Store
                {
                    Name = model.Name,
                    AddressId = address.AddressId

                };

                _unitOfWork.Stores.Add(store);
                _unitOfWork.Complete();





                return RedirectToAction("Index");
            }
            
            var createStore = new StoreViewModel();
            return View(createStore);
            
           
            
        }

        // GET: Store/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var store = _unitOfWork.Stores.Get(id);
            var address = _unitOfWork.Addresses.Get(store.AddressId);
            //store.Address = _unitOfWork.Addresses.Get(store.AddressId);
            var storeToUpdate=new StoreViewModel
            {
                Name = store.Name,
                TotalCycle = store.TotalCycle,
                Lat = address.Lat,
                Lon = address.Lon,
                Area = address.Area,
                City = address.City,
                Country = address.Country
            };
            if (storeToUpdate != null)
            {
                return View(storeToUpdate);
            }

            return RedirectToAction("Index");
        }

        // POST: Store/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, StoreViewModel store)
        {

            if (ModelState.IsValid)
            {
                var storeToUpdate = _unitOfWork.Stores.Get(id);
                var address = _unitOfWork.Addresses.Get(storeToUpdate.AddressId);

                address.Area = store.Area;
                address.City = store.City;
                address.Country = store.Country;
                address.Lat = store.Lat;
                address.Lon = store.Lon;
                
                
                _unitOfWork.Complete();
                
                storeToUpdate.Name = store.Name;
                storeToUpdate.TotalCycle = store.TotalCycle;
 
                _unitOfWork.Complete();
                
                return RedirectToAction("Index");
                
            }
            else
            {
                return RedirectToAction("Edit","Store");
            }
        }

        // GET: Store/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var store = _unitOfWork.Stores.Get(id);
            //store.Address = _unitOfWork.Addresses.Get(store.AddressId);
            if (store != null)
            {
                return View(store);
            }

            return HttpNotFound();
        }

        // POST: Store/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, Store store)
        {
            if (ModelState.IsValid)
            {
                var storetoupdate = _unitOfWork.Stores.Get(id);

                storetoupdate.IsDeleted = true;
                _unitOfWork.Complete();
                

                return RedirectToAction("Index");

            }

            return HttpNotFound();
        }
    }
}

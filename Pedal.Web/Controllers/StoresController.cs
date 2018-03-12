﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pedal.Data;
using Pedal.Models;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;

namespace Pedal.Web.Controllers
{
    public class StoresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationDbContext db = new ApplicationDbContext();

        public StoresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Stores
        public ActionResult Index()
        {
            var stores = _unitOfWork.Stores.GetAll();
            return View(stores);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _unitOfWork.Stores.Get(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            //ViewBag.AddressId = new SelectList(_unitOfWork.AddressRepository, "AddressId", "Area");
            //ViewBag.StoreId = new SelectList(db.Managers, "ManagerId", "IdentityId");
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreId,AddressId,TotalCycle,IsDeleted")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AddressId = new SelectList(db.UserAddresses, "AddressId", "Area", store.AddressId);
            //ViewBag.StoreId = new SelectList(db.Managers, "ManagerId", "IdentityId", store.StoreId);
            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AddressId = new SelectList(db.UserAddresses, "AddressId", "Area", store.AddressId);
            //ViewBag.StoreId = new SelectList(db.Managers, "ManagerId", "IdentityId", store.StoreId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreId,AddressId,TotalCycle,IsDeleted")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AddressId = new SelectList(db.UserAddresses, "AddressId", "Area", store.AddressId);
            //ViewBag.StoreId = new SelectList(db.Managers, "ManagerId", "IdentityId", store.StoreId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
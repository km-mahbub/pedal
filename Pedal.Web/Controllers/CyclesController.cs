using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pedal.Data;
using Pedal.Models;
using Pedal.Repositories.Interfaces;
using Pedal.Repositories;
using Pedal.Web.ViewModels;

namespace Pedal.Web.Controllers
{
    public class CyclesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CyclesController(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        // GET: Cycles
        public ActionResult Index()
        {
            
            return View(_unitOfWork.Cycles.GetAll());
        }

        // GET: Cycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycle cycle = _unitOfWork.Cycles.Get(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            return View(cycle);
        }

        // get: cycles/create
        public ActionResult Create()
        {
            //Stores = _unitOfWork.StoreRepository.GetAll();
            //Companies = _unitOfWork.CompanyRepository.GetAll();
            //var viewModel = new CycleViewModel
            //{

            ViewBag.Companies = _unitOfWork.Cycles.GetAll();
                ViewBag.Stores = _unitOfWork.Stores.GetAll();
                //Cycles = new Cycle()
           // };
            
            
            return View();
        }

        // POST: Cycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CycleViewModel NewCycle)
        {



            ViewBag.Test = NewCycle;

            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.CycleRepository.Add(cycle);
            //    _unitOfWork.Complete();
            //    //return RedirectToAction("Index");
            //}

            //ViewBag.CompanyId = new SelectList(_unitOfWork.Companies, "CompanyId", "Name", cycle.CompanyId);
            //ViewBag.StoreId = new SelectList(_unitOfWork.Stores, "StoreId", "StoreId", cycle.StoreId);
           return View("View");
        }

        //// GET: Cycles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cycle cycle = _unitOfWork.Cycles.Find(id);
        //    if (cycle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CompanyId = new SelectList(_unitOfWork.Companies, "CompanyId", "Name", cycle.CompanyId);
        //    ViewBag.StoreId = new SelectList(_unitOfWork.Stores, "StoreId", "StoreId", cycle.StoreId);
        //    return View(cycle);
        //}

        //// POST: Cycles/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CycleId,CycleStatusType,RentedHour,CycleType,CompanyId,StoreId,IsDeleted")] Cycle cycle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Entry(cycle).State = EntityState.Modified;
        //        _unitOfWork.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CompanyId = new SelectList(_unitOfWork.Companies, "CompanyId", "Name", cycle.CompanyId);
        //    ViewBag.StoreId = new SelectList(_unitOfWork.Stores, "StoreId", "StoreId", cycle.StoreId);
        //    return View(cycle);
        //}

        //// GET: Cycles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cycle cycle = _unitOfWork.Cycles.Find(id);
        //    if (cycle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cycle);
        //}

        //// POST: Cycles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cycle cycle = _unitOfWork.Cycles.Find(id);
        //    _unitOfWork.Cycles.Remove(cycle);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

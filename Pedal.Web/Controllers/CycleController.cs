using Pedal.Models;
using Pedal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pedal.Web.Controllers
{
    public class CycleController : Controller
    {
        IUnitOfWork _unitOfWork;

        public CycleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Cycle
        public ActionResult Index()
        {
            return View(_unitOfWork.Cycles.GetAllWithDetails());
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

            var Stores = _unitOfWork.Stores.GetAll();
            var Companies = _unitOfWork.Companies.GetAll();
            //var StoreList = new List<SelectListItem>();
            //var CompanyList = new List<SelectListItem>();


            //foreach (var item in Stores)
            //{
            //    StoreList.Add(new SelectListItem
            //    {
            //        Text = item.Name,
            //        Value = item.StoreId.ToString()
            //    });

            //}
            //foreach (var item in Companies)
            //{
            //    CompanyList.Add(new SelectListItem
            //    {
            //        Text = item.Name,
            //        Value = item.CompanyId.ToString()
            //    });

            //}

            ViewBag.StoreList = Stores;
            ViewBag.CompanyList = Companies;


            return View();
        }

        // POST: Cycle/Create
        [HttpPost]
        public ActionResult Create(Cycle cycle)
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.Cycles.Add(cycle);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View("text");

        }

        // GET: Cycle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cycle/Edit/5
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

        // GET: Cycle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cycle/Delete/5
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

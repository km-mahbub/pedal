using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pedal.Models;
using Pedal.Repositories;
using Pedal.Repositories.Interfaces;
using Pedal.Web.Models.ViewModels;

namespace Pedal.Web.Controllers
{
    public class CycleController : Controller
    {
        IUnitOfWork _unitOfWork = new UnitOfWork();
        // GET: Cycle
        public ActionResult Index()
        {
            IEnumerable<CycleViewModel> cList = _unitOfWork.CycleRepository.GetAll();
            return View(cList);
        }

        // GET: Cycle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cycle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cycle/Create
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

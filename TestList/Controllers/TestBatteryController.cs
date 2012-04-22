using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestList.Models;
using TestList.ViewModels;

namespace TestList.Controllers
{
    public class TestBatteryController : Controller
    {
        private ITestListRepository _repo;

        public TestBatteryController()
            : this(new TestListRepository())
        {
        }

        public TestBatteryController(ITestListRepository repository)
        {
            _repo = repository;
        }
        
        //
        // GET: /TestBattery/

        public ActionResult Index()
        {
            TestBatteryVM vm = new TestBatteryVM();
            var allTests = _repo.GetTests();
            vm.Tests = allTests;

            return View(vm);
        }

        //
        // GET: /TestBattery/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TestBattery/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TestBattery/Create

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
        
        //
        // GET: /TestBattery/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TestBattery/Edit/5

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

        //
        // GET: /TestBattery/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TestBattery/Delete/5

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

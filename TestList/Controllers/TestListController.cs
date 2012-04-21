using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestList.Models;

namespace TestList.Controllers
{
    public class TestListController : Controller
    {
        private ITestListRepository _repo;

        public TestListController()
            : this(new TestListRepository())
        {
            
        }

        public TestListController(ITestListRepository repository)
        {
            _repo = repository;
        }

        //
        // GET: /TestList/

        public ActionResult Index()
        {
            var tests = _repo.GetTests();
            
            return View(tests);
        }

        //
        // GET: /TestList/Details/5

        public ActionResult Details(int id)
        {
            var test = _repo.GetTestById(id);
            
            return View(test);
        }

        //
        // GET: /TestList/Create

        public ActionResult Create()
        {

            return View();
        } 

        //
        // POST: /TestList/Create

        [HttpPost]
        public ActionResult Create(Test test)
        {
            try
            {
                _repo.InsertTest(test);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /TestList/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TestList/Edit/5

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            try
            {
                _repo.EditTest(test);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TestList/Delete/5
 
        public ActionResult Delete(int id)
        {
            _repo.DeleteTest(id);
            
            return RedirectToAction("Index");
        }

        //
        // POST: /TestList/Delete/5

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

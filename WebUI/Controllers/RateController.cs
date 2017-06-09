using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class RateController : Controller
    {
        IRateRepository repository;

        public RateController(IRateRepository repo)
        {
            repository = repo;
        }
        // GET: Rate
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(repository.Rates);
        }

        // GET: Rate/Details/5
        public ActionResult Details(int id)
        {
            var dbEntry = repository.Get(id);
            if (dbEntry == null)
                return HttpNotFound();
            return View(dbEntry);
        }

        // GET: Rate/Create
        public ActionResult Create()
        {
            return View(new Rate());
        }

        // POST: Rate/Create
        [HttpPost]
        public ActionResult Create(Rate rate)
        {
            try
            {
                // TODO: Add insert logic here
                repository.Save(rate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rate);
            }
        }

        // GET: Rate/Edit/5
        public ActionResult Edit(int id)
        {
            var dbEntry = repository.Get(id);
            if (dbEntry == null)
                return HttpNotFound();
            return View(dbEntry);
        }

        // POST: Rate/Edit/5
        [HttpPost]
        public ActionResult Edit(Rate rate)
        {
            try
            {
                // TODO: Add update logic here
                repository.Save(rate);
                return RedirectToAction("List");
            }
            catch
            {
                return View(rate);
            }
        }

        // GET: Rate/Delete/5
        public ActionResult Delete(int id)
        {
            var dbEntry = repository.Delete(id);
            return RedirectToAction("List");
        }
    }
}

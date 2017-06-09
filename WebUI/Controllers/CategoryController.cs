using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository repository;

        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }
        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(repository.Categories);
        }

        public ActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            repository.Save(category);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var dbEntry = repository.Delete(id);
            string message = "Объект не существует в базе данных";
            if (dbEntry != null)
                message = String.Format("Успешное удаление!\nКатегория:\t{0}\nID:{1}", dbEntry.Description, dbEntry.ID);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var dbEntry = repository.Get(id);
            if (dbEntry == null)
                return HttpNotFound();
            return View(dbEntry);
        }

        public ActionResult Edit(int id)
        {
            var dbEntry = repository.Get(id);
            if (dbEntry == null)
                return HttpNotFound();
            return View(dbEntry);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            repository.Save(category);
            return View(category);
        }
        
    }
}
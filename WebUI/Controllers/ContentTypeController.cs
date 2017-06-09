using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class ContentTypeController : Controller
    {
        IContentTypeRepository repository;

        public ContentTypeController(IContentTypeRepository repo)
        {
            repository = repo;
        }
        // GET: ContentType
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(repository.ContentTypes);
        }

        public ActionResult Create()
        {
            return View(new ContentType());
        }

        [HttpPost]
        public ActionResult Create(ContentType contentType)
        {
            repository.Save(contentType);
            return View(contentType);
        }

        public ActionResult Delete(int id)
        {
            var dbEntry = repository.Delete(id);
            string message = "Объект не существует в базе данных";
            if (dbEntry != null)
                message = String.Format("Успешное удаление!\nТип:\t{0}\nID:{1}", dbEntry.Type, dbEntry.ID);
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
        public ActionResult Edit(ContentType contentType)
        {
            try
            {
                repository.Save(contentType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(contentType);
            }
        }
    }
}
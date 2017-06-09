using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class ContentController : Controller
    {
        IContentRepository repository;

        public ContentController(IContentRepository repo)
        {
            repository = repo;
        }
        // GET: Content
        public ActionResult Index()
        {
            return View(repository.Contents);
        }

        public ActionResult Create()
        {
            return View(new Content());
        }

        [HttpPost]
        public ActionResult Create(Content content)
        {
            repository.Save(content);
            return RedirectToAction("Index");
        }
    }
}
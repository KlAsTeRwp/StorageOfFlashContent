using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class AdminPanelController : Controller
    {
        IContentRepository repository;

        public AdminPanelController(IContentRepository repo)
        {
            repository = repo;
        }
        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.ViewModels;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        IContentRepository contentRepository;

        public HomeController(IContentRepository contentRepo)
        {
            contentRepository = contentRepo;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<ContentListViewModel> list = new List<ContentListViewModel>();
            foreach (var item in contentRepository.Contents)
            {
                ContentListViewModel temp = new ContentListViewModel
                {
                    AverageRate = (item.Rates.Count > 0) ? item.Rates.Average(x => x.Value) : 0.00,
                    Category = item.Category.Name,
                    ContentType = item.ContentType.Type,
                    Description = item.Description,
                    Name = item.Name,
                    ID = item.ID
                };
                list.Add(temp);
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            Content temp = contentRepository.Get(id);
            if (temp == null)
                return HttpNotFound();
            ContentListViewModel content = new ContentListViewModel
            {
                AverageRate = (temp.Rates.Count > 0) ? temp.Rates.Average(x => x.Value) : 0.00,
                Category = temp.Category.Name,
                ContentType = temp.ContentType.Type,
                Description = temp.Description,
                Name = temp.Name,
                ID = temp.ID
            };
            return View(content);
        }
    }
}
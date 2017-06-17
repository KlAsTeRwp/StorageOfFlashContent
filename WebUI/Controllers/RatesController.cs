using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class RatesController : Controller
    {
        IRateRepository rateRepository;
        IContentRepository contentRepository;

        public RatesController(IRateRepository rateRepo, IContentRepository contentRepo)
        {
            rateRepository = rateRepo;
            contentRepository = contentRepo;
        }
        // GET: Rates
        public ActionResult Index()
        {
            List<RateViewModel> list = new List<RateViewModel>();
            foreach (var item in rateRepository.Rates.ToList())
            {
                RateViewModel temp = new RateViewModel()
                {
                    Description = item.Description,
                    ID = item.ID,
                    Name = item.Content.Name,
                    Value = item.Value
                };
                list.Add(temp);
            }

            return View(list);
        }

        // GET: Rates/Details/5
        public ActionResult Details(int id)
        {
            Rate rate = rateRepository.Get(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            RateViewModel rateViewModel = new RateViewModel()
            {
                Value = rate.Value,
                Name = rate.Content.Name,
                ID = rate.ID,
                Description = rate.Description
            };
            return View(rateViewModel);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            var newRateEditViewModel = new RateEditViewModel()
            {
                Contents = contentRepository.Contents
            };
            return View(newRateEditViewModel);
        }

        // POST: Rates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateEditViewModel rate)
        {
            if (ModelState.IsValid)
            {
                Rate newRate = new Rate()
                {
                    ContentID = rate.ContentID,
                    Description = rate.Description,
                    ID = 0,
                    Value = rate.Value
                };
                rateRepository.Save(newRate);
                return RedirectToAction("Index");
            }

            return View(rate);
        }

        // GET: Rates/Edit/5
        public ActionResult Edit(int id)
        {
            Rate rate = rateRepository.Get(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            RateEditViewModel rateEditViewModel = new RateEditViewModel
            {
                ContentID = rate.ContentID,
                Description = rate.Description,
                ID = rate.ID,
                Value = rate.Value,
                Contents = contentRepository.Contents
            };
            return View(rateEditViewModel);
        }

        // POST: Rates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RateEditViewModel rateEdit)
        {
            if (ModelState.IsValid)
            {
                var rate = new Rate()
                {
                    ContentID = rateEdit.ContentID,
                    Value = rateEdit.Value,
                    Description = rateEdit.Description,
                    ID = rateEdit.ID
                };
                rateRepository.Save(rate);
                return RedirectToAction("Index");
            }
            return View(rateEdit);
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(int id)
        {
            Rate rate = rateRepository.Get(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            RateViewModel rateDeleteViewModel = new RateViewModel()
            {
                Description = rate.Description,
                ID = rate.ID,
                Name = rate.Content.Name,
                Value = rate.Value
            };
            return View(rateDeleteViewModel);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rateRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

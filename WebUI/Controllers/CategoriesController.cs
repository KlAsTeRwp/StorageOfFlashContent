using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models.ViewModels;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepo)
        {
            categoryRepository = categoryRepo;
        }
        // GET: Categories
        public ActionResult Index()
        {
            List<CategoryListViewModel> list = new List<CategoryListViewModel>();
            foreach (var item in categoryRepository.Categories)
            {
                CategoryListViewModel categoryListViewModel = new CategoryListViewModel()
                {
                    ID = item.ID,
                    Name = item.Name
                };
                list.Add(categoryListViewModel);
            }
            return View(list);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Save(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Save(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

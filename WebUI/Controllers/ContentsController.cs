using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models.ViewModels;
using System.IO.Compression;
using System.IO;

namespace WebUI.Controllers
{
    public class ContentsController : Controller
    {
        IContentRepository contentRepository;
        IContentTypeRepository contentTypeRepository;
        ICategoryRepository categoryRepository;

        public ContentsController(IContentRepository contentRepo, IContentTypeRepository contentTypeRepo, ICategoryRepository categoryRepo)
        {
            contentRepository = contentRepo;
            contentTypeRepository = contentTypeRepo;
            categoryRepository = categoryRepo;
        }
        // GET: Contents
        public ActionResult Index()
        {
            List<ContentListViewModel> list = new List<ContentListViewModel>();
            foreach (var item in contentRepository.Contents)
            {
                ContentListViewModel temp = new ContentListViewModel
                {
                    ID = item.ID,
                    Category = item.Category.Name,
                    ContentType = item.ContentType.Type,
                    Description = item.Description,
                    Name = item.Name,
                    AverageRate = (item.Rates.Count > 0) ? item.Rates.Average(x => x.Value) : 0.00
                };
                list.Add(temp);
            }
            return View(list);
        }

        public FileContentResult GetFile(int id)
        {
            Content returnedFile = contentRepository.Get(id);
            string FileName = returnedFile.Name + returnedFile.ContentType.Extensions;
            byte[] Data = returnedFile.Data;
            return File(Data, returnedFile.ContentType.Type, FileName);
        }

        public String GetData(int id)

        {
            Content returnedFile = contentRepository.Get(id);
            string FileName = returnedFile.Name + returnedFile.ContentType.Extensions;
            byte[] Data = returnedFile.Data;
            return Convert.ToBase64String(returnedFile.Data);
        }

        // GET: Contents/Details/5
        public ActionResult Details(int id)
        {
            Content content = contentRepository.Get(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Contents/Create
        public ActionResult Create()
        {
            ContentCreateViewModel contentCreateViewModel = new ContentCreateViewModel()
            {
                Categories = categoryRepository.Categories,
                ContentTypes = contentTypeRepository.ContentTypes
            };
            return View(contentCreateViewModel);
        }

        // POST: Contents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase upload, ContentCreateViewModel content)
        {
            if (ModelState.IsValid && upload != null)
            {
                Content newContent = new Content()
                {
                    CategoryID = content.CategoryID,
                    ContentTypeID = content.ContentTypeID,
                    Description = content.Description,
                    Name = content.Name
                };
                byte[] buffer = new byte[upload.ContentLength];
                upload.InputStream.Read(buffer, 0, upload.ContentLength);
                newContent.Data = buffer;
                contentRepository.Save(newContent);
                return RedirectToAction("Index");
            }
            content.Categories = categoryRepository.Categories;
            content.ContentTypes = contentTypeRepository.ContentTypes;
            return View(content);
        }

        // GET: Contents/Edit/5
        public ActionResult Edit(int id)
        {
            Content content = contentRepository.Get(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ContentEditViewModel contentEditViewModel = new ContentEditViewModel
            {
                CategoryID = content.CategoryID,
                ContentTypeID = content.ContentTypeID,
                Description = content.Description,
                ID = content.ID,
                Name = content.Name,
                File = content.Data,
                Categories = categoryRepository.Categories,
                ContentTypes = contentTypeRepository.ContentTypes
            };
            return View(content);
        }

        // POST: Contents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase upload, ContentEditViewModel content)
        {
            if (ModelState.IsValid)
            {
                Content changedContent = new Content()
                {
                    Name = content.Name,
                    Description = content.Description,
                    ID = content.ID,
                    ContentTypeID = content.ContentTypeID,
                    CategoryID = content.CategoryID,
                    Data = content.File
                };
                if (upload != null)
                {
                    byte[] buffer = new byte[upload.ContentLength];
                    upload.InputStream.Read(changedContent.Data, 0, upload.ContentLength);
                    changedContent.Data = buffer;
                }
                contentRepository.Save(changedContent);
                return RedirectToAction("Index");
            }
            return View(content);
        }

        // GET: Contents/Delete/5
        public ActionResult Delete(int id)
        {
            Content content = contentRepository.Get(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ContentViewModel tempModel = new ContentViewModel
            {
                Category = content.Category.Name,
                Name = content.Name,
                Description = content.Description,
                ID = content.ID,
                ContentType = content.ContentType.Type,
                Rates = content.Rates
            };
            return View(tempModel);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

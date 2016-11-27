namespace OnlineLibrary.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using OnlineLibrary.Models;


    [Authorize]
    public class BookController:BaseController
    {
        public BookController(IOnlineLibraryDbData data, User userProfile) : base(data, userProfile)
        {
        }

        //
        // GET: /Book/Add

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Book/Add

        [HttpPost]
        public ActionResult Add(BookBindingModel model)
        {
            if (ModelState.IsValid)
            {

                string folderPath = "~/media/covers/";
                bool existFolder = Directory.Exists(Server.MapPath(folderPath));
                if (!existFolder)
                {
                    Directory.CreateDirectory(Server.MapPath(folderPath));
                }
                var timeNowToString = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
                var imageName = timeNowToString + model.ImageFile.FileName ;
                model.ImageFile.SaveAs(HttpContext.Server.MapPath(folderPath + imageName));
                var newBook = new Book
                {
                    Name = model.Name,
                    CreatedOn = DateTime.Now,
                    Genre = model.Genre,
                    PageCount = model.PageCount,
                    ImagePath = imageName,
                    CreatorId = User.Identity.GetUserId()
                };
                this.Data.Books.Add(newBook);
                this.Data.SaveChanges();
                return RedirectToAction("List");
            }
            return View(model);
        }
        //
        // GET: /Book/List/
        [HttpGet]
        public ActionResult List()
        {
            var books = this.Data.Books.All()
                .OrderByDescending(b=> b.CreatedOn)
                .Select(BookInListViewModel.Create)
                .ToList();

            return View(books);
        }
    }
}
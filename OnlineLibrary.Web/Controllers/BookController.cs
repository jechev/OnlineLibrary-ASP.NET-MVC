namespace OnlineLibrary.Web.Controllers
{
    using System;
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
                bool existFolder = System.IO.Directory.Exists(Server.MapPath(folderPath));
                if (!existFolder)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(folderPath));
                }
                model.ImageFile.SaveAs(HttpContext.Server.MapPath(folderPath + model.ImageFile.FileName));

                var newBook = new Book
                {
                    Name = model.Name,
                    CreatedOn = DateTime.Now,
                    Genre = model.Genre,
                    ImagePath = model.ImageFile.FileName,
                    CreatorId = User.Identity.GetUserId()
                };
                Data.Books.Add(newBook);
                Data.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
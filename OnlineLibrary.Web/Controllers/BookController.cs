﻿namespace OnlineLibrary.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using OnlineLibrary.Models;
    using PagedList;


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
        public ActionResult List(int? page,string query,string searchType)
        {
            Regex searchPagesCount = new Regex(@"(\d+)\W+(\d+)");
            var pageNumber = page ?? 1;
            var books = this.Data.Books.All()
                .OrderByDescending(b=> b.CreatedOn)
                .Select(BookInListViewModel.Create) 
                .ToList();
            var viewModel = new ListBooksViewModel();

            if (!string.IsNullOrEmpty(query))
            {
                switch (searchType)
                {
                    case "1":
                        books = books.Where(b => b.Name.Equals(query)).ToList();
                        break;
                    case "2":
                        books = books.Where(b => b.Genre.Equals(query)).ToList();
                        break;
                    case "3":
                        Match matchNumbers = searchPagesCount.Match(query);
                        var firstNumber = Int32.Parse(matchNumbers.Groups[1].Value);
                        var seconNumber = Int32.Parse(matchNumbers.Groups[2].Value);
                        books = books.Where(b => b.PageCount > firstNumber && b.PageCount< seconNumber).ToList();
                        break;
                }

                viewModel.SearchBooks = books;
                return PartialView("_SearchBooksPartial", viewModel);
            }

            var pageOfBooks = books.ToPagedList(pageNumber, 7);
            viewModel.Books = pageOfBooks;

            if ((Request.IsAjaxRequest() && string.IsNullOrEmpty(query)))
            {
                return PartialView("_ListBooksPartial", viewModel);
            }

            return View(viewModel);
        }
    }
}
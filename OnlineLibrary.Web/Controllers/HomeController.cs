using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Web.Controllers
{
    using Data;
    using OnlineLibrary.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
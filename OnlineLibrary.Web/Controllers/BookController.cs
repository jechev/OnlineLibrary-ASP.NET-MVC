namespace OnlineLibrary.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
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
    }
}
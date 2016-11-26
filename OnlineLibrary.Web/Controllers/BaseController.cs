using System.Web.Mvc;

namespace OnlineLibrary.Web.Controllers
{
    using Data;
    using OnlineLibrary.Models;

    public abstract class BaseController : Controller
    {
       
        protected BaseController(OnlineLibraryDbContext data)
        {
            this.Data = data;
        }
        protected BaseController(OnlineLibraryDbContext data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected OnlineLibraryDbContext Data { get; private set; }

        protected User UserProfile { get; private set; }

    }
}
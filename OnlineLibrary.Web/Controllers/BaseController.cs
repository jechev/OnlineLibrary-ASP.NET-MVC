using System.Web.Mvc;

namespace OnlineLibrary.Web.Controllers
{
    using Data;
    using OnlineLibrary.Models;

    public abstract class BaseController : Controller
    {
       
        protected BaseController(IOnlineLibraryDbData data)
        {
            this.Data = data;
        }
        protected BaseController(IOnlineLibraryDbData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IOnlineLibraryDbData Data { get; private set; }

        protected User UserProfile { get; private set; }

    }
}
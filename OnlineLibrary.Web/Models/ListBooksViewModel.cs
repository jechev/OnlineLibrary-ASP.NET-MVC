namespace OnlineLibrary.Web.Models
{
    using System.Collections.Generic;
    using PagedList;

    public class ListBooksViewModel
    {
        public IPagedList<BookInListViewModel> Books { get; set; }
        public List<BookInListViewModel> SearchBooks { get; set; }
    }
}
namespace OnlineLibrary.Web.Models
{
    using PagedList;

    public class ListBooksViewModel
    {
        public IPagedList<BookInListViewModel> Books { get; set; }
    }
}
namespace OnlineLibrary.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using OnlineLibrary.Models;

    public class BookInListViewModel
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public string ImgPath { get; set; }

        [DisplayFormat(DataFormatString = "{{0:yyyy/MM/dd}}")]
        public DateTime CreatedOn { get; set; }

        public int PageCount { get; set; }

        public static Expression<Func<Book, BookInListViewModel>> Create
        {
            get
            {
                return book => new BookInListViewModel()
                {
                    Name = book.Name,
                    Genre = book.Genre.ToString(),
                    ImgPath = book.ImagePath,
                    CreatedOn = book.CreatedOn,
                    PageCount = book.PageCount
                };
            }
        }
    }
}
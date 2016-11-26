namespace OnlineLibrary.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Attributes;
    using OnlineLibrary.Models.Enums;

    public class BookBindingModel
    {
        [Required(ErrorMessage = "A Book Title is required")]
        [Display(Name = "Boot Title")]
        [StringLength(255, ErrorMessage = "The {0} must be min {2} and max {1} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public GenreType Genre { get; set; }

        [ValidateFile(6291456)]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Page Count")]

        public int PageCount { get; set; }


    }
}
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

        [ValidateFile(4194304)]
        [Required(ErrorMessage = "An Image is required")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Page Count")]
        [Required(ErrorMessage = "Page Count must be number")]
        [Range(5,10000,ErrorMessage = "Please enter number from {1} to {2}")]
        public int PageCount { get; set; }


    }
}
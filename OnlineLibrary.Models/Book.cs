namespace OnlineLibrary.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public GenreType Genre { get; set; }

        public int PageCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }
        
        public virtual User Creator { get; set; }
    }
}

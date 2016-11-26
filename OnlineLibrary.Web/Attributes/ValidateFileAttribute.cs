namespace OnlineLibrary.Web.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ValidateFileAttribute:ValidationAttribute
    {
        public long MaxSizeInBytes { get; set; }

        public ValidateFileAttribute(long maxSizeInBytes)
        {
            this.MaxSizeInBytes = maxSizeInBytes;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] allowedFormats = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            if (value == null)
            {
                return null;
            }

            HttpPostedFileBase file = value as HttpPostedFileBase;

            if (!allowedFormats.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                return new ValidationResult("Selected file is not a valid image. Supports formats are: " + string.Join(", ",allowedFormats));
            }
             
            if ((long)(file.ContentLength) > this.MaxSizeInBytes)
            {
                var maxSizeInMB = this.MaxSizeInBytes / 1024 / 1024;
                return new ValidationResult(string.Format("Max allowed size is: {0:F2} MB", maxSizeInMB));
            }

            return ValidationResult.Success;
        }
    }
}
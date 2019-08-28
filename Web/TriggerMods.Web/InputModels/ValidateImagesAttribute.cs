namespace TriggerMods.Web.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class ValidateImagesAttribute : ValidationAttribute
    {
        private const string FileNotFoundMessage = "File not found.";
        private const string FileExtensionMessage = "The file must be jpg or png";


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var supportedTypes = new[] { "jpg", "png" };
            var files = value as ICollection<IFormFile>;

            foreach (var img in files)
            {
                if (img == null)
                {
                    return new ValidationResult(FileNotFoundMessage);
                }

                var fileExt = System.IO.Path.GetExtension(img.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    return new ValidationResult(FileExtensionMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

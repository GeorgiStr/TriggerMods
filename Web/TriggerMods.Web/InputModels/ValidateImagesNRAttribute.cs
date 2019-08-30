namespace TriggerMods.Web.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class ValidateImagesNRAttribute : ValidationAttribute
    {
        private const string FileExtensionMessage = "The file must be jpg or png";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var supportedTypes = new[] { "jpg", "png" };
            var files = value as ICollection<IFormFile>;
            if (files != null)
            {
                foreach (var img in files)
                {
                    var fileExt = System.IO.Path.GetExtension(img.FileName).Substring(1);
                    if (!supportedTypes.Contains(fileExt))
                    {
                        return new ValidationResult(FileExtensionMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}

namespace TriggerMods.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class ValidateImageNRAttribute : ValidationAttribute
    {
        private const string FileExtensionMessage = "The file must be jpg or png";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var supportedTypes = new[] { "jpg", "png" };
            var file = value as IFormFile;
            if (file != null)
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    return new ValidationResult(FileExtensionMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

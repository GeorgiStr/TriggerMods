using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.InputModels
{
    public class ValidateImageAttribute : ValidationAttribute
    {
        private const string FileNotFoundMessage = "File not found.";
        private const string FileExtensionMessage = "The file must be jpg or png";
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var supportedTypes = new[] { "jpg", "png" };
            var file = value as IFormFile;

            if (file == null)
            {
                return new ValidationResult(FileNotFoundMessage);
            }

            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
            if (!supportedTypes.Contains(fileExt))
            {
                return new ValidationResult(FileExtensionMessage);
            }

            return ValidationResult.Success;
        }
    }
}

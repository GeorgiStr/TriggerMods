namespace TriggerMods.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class ValidateFileNRAttribute : ValidationAttribute
    {
        private const int Filesize = 100;
        private const string FileExtensionMessage = "The file must be rar or zip";
        private string fileSizeMessage = $"The file must be below {Filesize} MB";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var supportedTypes = new[] { "zip", "rar" };
            var file = value as IFormFile;

            if (file != null)
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    return new ValidationResult(FileExtensionMessage);
                }
                else if (file.Length > (Filesize * 1024 * 1024))
                {
                    return new ValidationResult(fileSizeMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}

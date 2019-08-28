namespace TriggerMods.Web.InputModels
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditModInputModel
    {
        public const int NameMaxLength = 30;
        public const int NameMinLength = 5;
        public const int VersionMaxLength = 10;
        public const int VersionMinLength = 1;
        public const int DescriptionMaxLength = 300;
        public const int DescriptionMinLength = 5;
        public const string InputLength = "Field \"{0}\" must be between {2} and  {1} characters.";

        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InputLength)]
        public string Name { get; set; }

        [StringLength(VersionMaxLength, MinimumLength = VersionMinLength, ErrorMessage = InputLength)]
        public string Version { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = InputLength)]
        public string Description { get; set; }

        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InputLength)]
        public string FileName { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = InputLength)]
        public string FileDescription { get; set; }

        [Display(Name = "Image")]
        [ValidateImageNR]
        public IFormFile MainImage { get; set; }

        [ValidateFile]
        public IFormFile MainFile { get; set; }

        [ValidateImages]
        public ICollection<IFormFile> Gallery { get; set; }

        public string GameId { get; set; }
    }
}

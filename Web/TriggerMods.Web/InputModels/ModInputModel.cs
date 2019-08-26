﻿namespace TriggerMods.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ModInputModel
    {
        public const int NameMaxLength = 30;
        public const int NameMinLength = 5;
        public const int VersionMaxLength = 30;
        public const int VersionMinLength = 5;
        public const int DescriptionMaxLength = 30;
        public const int DescriptionMinLength = 5;
        public const string Required = "Field \"{0}\" is required.";
        public const string InputLength = "Field \"{0}\" must be between {2} and  {1} characters.";

        [Required(ErrorMessage = Required)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InputLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = Required)]
        [StringLength(VersionMaxLength, MinimumLength = VersionMinLength, ErrorMessage = InputLength)]
        public string Version { get; set; }

        [Required(ErrorMessage = Required)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = InputLength)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = Required)]
        public IFormFile MainImage { get; set; }
    }
}
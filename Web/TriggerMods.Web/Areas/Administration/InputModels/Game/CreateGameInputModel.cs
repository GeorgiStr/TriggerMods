namespace TriggerMods.Web.Areas.Administration.InputModels.Game
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TriggerMods.Web.InputModels;

    public class CreateGameInputModel
    {
        public const int GameNameMaxLength = 30;
        public const int GameNameMinLength = 5;
        public const string Required = "Field \"{0}\" is required.";
        public const string GameNameLength = "Field \"{0}\" must be between {2} and  {1} characters.";

        [Required(ErrorMessage = Required)]
        [StringLength(GameNameMaxLength, MinimumLength = GameNameMinLength, ErrorMessage = GameNameLength)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = Required)]
        [ValidateImage]
        public IFormFile MainImage { get; set; }

        public string Id { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.Areas.Administration.InputModels.Game
{
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
        public IFormFile MainImage { get; set; }
    }
}

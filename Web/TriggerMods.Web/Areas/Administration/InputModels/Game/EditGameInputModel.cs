using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Web.InputModels;

namespace TriggerMods.Web.Areas.Administration.InputModels.Game
{
    public class EditGameInputModel
    {
        public const int GameNameMaxLength = 30;
        public const int GameNameMinLength = 5;
        public const string GameNameLength = "Field \"{0}\" must be between {2} and  {1} characters.";


        [StringLength(GameNameMaxLength, MinimumLength = GameNameMinLength, ErrorMessage = GameNameLength)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [ValidateImageNR]
        public IFormFile MainImage { get; set; }

        public string Id { get; set; }
    }
}

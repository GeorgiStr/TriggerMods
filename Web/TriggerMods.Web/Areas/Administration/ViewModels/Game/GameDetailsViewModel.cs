using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Data.Models;

namespace TriggerMods.Web.Areas.Administration.ViewModels.Game
{
    public class GameDetailsViewModel
    {
        public string Name { get; set; }

        public string GamePicturePath { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModCount { get; set; }

        public int TotalDownloadCount { get; set; }

        
    }
}

namespace TriggerMods.Web.Areas.Administration.ViewModels.Game
{
    using System;

    public class GameDetailsViewModel
    {
        public string Name { get; set; }

        public string GamePicturePath { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModCount { get; set; }

        public int TotalDownloadCount { get; set; }

        
    }
}

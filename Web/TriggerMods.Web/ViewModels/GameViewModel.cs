using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.ViewModels
{
    public class GameViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string GamePicturePath { get; set; }

        public int ModCount { get; set; }

        public int TotalDownloadCount { get; set; }
    }
}

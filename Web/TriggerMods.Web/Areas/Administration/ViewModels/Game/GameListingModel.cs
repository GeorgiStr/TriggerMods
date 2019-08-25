using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.Areas.Administration.ViewModels.Game
{
    public class GameListingModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ModCount { get; set; }

        public int TotalDownlaodCount { get; set; }
    }
}

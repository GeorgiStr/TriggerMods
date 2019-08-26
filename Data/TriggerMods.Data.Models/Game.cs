using System;
using System.Collections.Generic;
using System.Text;
using TriggerMods.Data.Common.Models;

namespace TriggerMods.Data.Models
{
    public class Game : BaseModel<string>
    {
        public Game()
        {
            this.Mods = new HashSet<Mod>();
        }

        public string Name { get; set; }

        public string GamePicturePath { get; set; }

        public int ModCount { get; set; }

        public int TotalDownloadCount { get; set; }

        public ICollection<Mod> Mods { get; set; }
    }
}

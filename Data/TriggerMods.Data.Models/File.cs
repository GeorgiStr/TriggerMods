using System;
using System.Collections.Generic;
using System.Text;
using TriggerMods.Data.Common.Models;

namespace TriggerMods.Data.Models
{
    public class File : BaseModel<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double FileSize { get; set; } 

        public string FilePath { get; set; }

        public FileStatus Status { get; set; }

        public int DownlaodCount { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }
    }
}

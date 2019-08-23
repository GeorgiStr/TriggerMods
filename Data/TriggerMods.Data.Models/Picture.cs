using System;
using System.Collections.Generic;
using System.Text;
using TriggerMods.Data.Common.Models;

namespace TriggerMods.Data.Models
{
    public class Picture : BaseModel<string>
    {
        public string FilePath { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }
    }
}

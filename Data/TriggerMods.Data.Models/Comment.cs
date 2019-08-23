using System;
using System.Collections.Generic;
using System.Text;
using TriggerMods.Data.Common.Models;

namespace TriggerMods.Data.Models
{
    public class Comment : BaseModel<string>
    {
        public string Content { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }
    }
}

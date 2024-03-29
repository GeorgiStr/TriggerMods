﻿namespace TriggerMods.Data.Models
{
    using TriggerMods.Data.Common.Models;

    public class ReportMod : BaseModel<string>
    {
        public string Reason { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }

        public string UploaderId { get; set; }
        public ApplicationUser Uploader { get; set; }

        public string ReporterId { get; set; }
        public ApplicationUser Reporter { get; set; }
    }
}

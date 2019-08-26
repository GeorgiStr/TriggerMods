using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.Areas.Administration.ViewModels.Mod
{
    public class ModListingViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string MainPicturePath { get; set; }

        public string UploaderName { get; set; }

        public int TotalDownloadCount { get; set; }

        public int VoteCount { get; set; }

        public bool Visible { get; set; }
    }
}

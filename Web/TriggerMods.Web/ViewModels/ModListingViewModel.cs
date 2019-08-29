using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.ViewModels
{
    public class ModListingViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Game { get; set; }

        public string GameId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string MainPicturePath { get; set; }

        public string UploaderName { get; set; }

        public int TotalDownloadCount { get; set; }

        public int VoteCount { get; set; }

        public bool Visible { get; set; }
    }
}

namespace TriggerMods.Web.ViewModels
{
    using System;
    using TriggerMods.Data.Models;

    public class FileViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public double FileSize { get; set; }

        public string FilePath { get; set; }

        public FileStatus Status { get; set; }

        public int DownlaodCount { get; set; }

        public string ModId { get; set; }
    }
}

namespace TriggerMods.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ModViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string MainPicturePath { get; set; }

        public int Views { get; set; }

        public int TotalDownloadCount { get; set; }

        public int VoteCount { get; set; }

        public bool Visible { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public string GameId { get; set; }

        public string Game { get; set; }

        public bool Voted { get; set; }

        public ICollection<string> Pictures { get; set; }

        public ICollection<FileViewModel> Files { get; set; }

        public ICollection<CommentsViewModel> Comments { get; set; }
    }
}

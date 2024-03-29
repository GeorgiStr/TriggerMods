﻿

namespace TriggerMods.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TriggerMods.Data.Common.Models;

    public class Mod : BaseModel<string>
    {
        public Mod()
        {
            this.Pictures = new HashSet<Picture>();
            this.Files = new HashSet<File>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.Visible = false;
        }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string MainPicturePath { get; set; }

        public int Views { get; set; }

        public int TotalDownloadCount { get; set; }

        public int VoteCount { get; set; }

        public bool Visible { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<File> Files { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}

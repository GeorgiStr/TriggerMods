// ReSharper disable VirtualMemberCallInConstructor
namespace TriggerMods.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TriggerMods.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Comments = new HashSet<Comment>();
            this.Mods = new HashSet<Mod>();
            this.SentPMs = new HashSet<PrivateMessage>();
            this.ReceviedPMs = new HashSet<PrivateMessage>();
            this.VotedMods = new HashSet<Vote>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public int CommentsCount { get; set; }

        public int ModCount { get; set; }

        public int RemovedMods { get; set; }

        public int TotalUserVotes { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Mod> Mods { get; set; }

        [InverseProperty("Sender")]
        public ICollection<PrivateMessage> SentPMs { get; set; }

        [InverseProperty("Receiver")]
        public ICollection<PrivateMessage> ReceviedPMs { get; set; }

        public ICollection<Vote> VotedMods { get; set; }
    }
}

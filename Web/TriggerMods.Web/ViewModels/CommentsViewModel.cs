namespace TriggerMods.Web.ViewModels
{
    using System;

    public class CommentsViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ModId { get; set; }
    }
}

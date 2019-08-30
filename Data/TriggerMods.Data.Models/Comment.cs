namespace TriggerMods.Data.Models
{
    using TriggerMods.Data.Common.Models;

    public class Comment : BaseModel<string>
    {
        public string Content { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }
    }
}

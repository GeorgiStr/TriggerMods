namespace TriggerMods.Data.Models
{
    using TriggerMods.Data.Common.Models;

    public class Picture : BaseModel<string>
    {
        public string FilePath { get; set; }

        public string ModId { get; set; }
        public Mod Mod { get; set; }
    }
}

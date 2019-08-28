namespace TriggerMods.Web.ViewModels
{
    using System.Collections.Generic;

    public class ListOfModsViewModel
    {
        public string Game { get; set; }

        public IList<ModListingViewModel> Mods { get; set; }
}
}

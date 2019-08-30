namespace TriggerMods.Web.ViewModels
{
    using System.Collections.Generic;

    public class InboxViewModel
    {
        public IList<PrivateMessageViewModel> Sent { get; set; }

        public IList<PrivateMessageViewModel> Received { get; set; }
    }
}

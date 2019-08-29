using System.Collections.Generic;

namespace TriggerMods.Web.ViewModels
{
    public class InboxViewModel
    {
        public IList<PrivateMessageViewModel> Sent;

        public IList<PrivateMessageViewModel> Received;
    }
}

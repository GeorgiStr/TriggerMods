namespace TriggerMods.Web.ViewModels
{
    using System;

    public class PrivateMessageViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Caption { get; set; }

        public string Content { get; set; }

        public string Quote { get; set; }

        public string SenderId { get; set; }

        public string SenderName { get; set; }

        public string ReceiverId { get; set; }

        public string ReceiverName { get; set; }
    }
}

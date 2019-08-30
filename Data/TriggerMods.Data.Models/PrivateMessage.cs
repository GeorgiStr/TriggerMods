namespace TriggerMods.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using TriggerMods.Data.Common.Models;

    public class PrivateMessage : BaseModel<string>
    {
        public PrivateMessage()
        {
            this.Seen = false;
            this.SerderHide = false;
            this.ReceiverHide = false;
        }

        public string Caption { get; set; }

        public string Content { get; set; }

        public string Quote { get; set; }

        public bool Seen { get; set; }

        public bool SerderHide { get; set; }

        public bool ReceiverHide { get; set; }

        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
    }
}

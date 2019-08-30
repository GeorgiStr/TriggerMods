namespace TriggerMods.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PrivateMessageInputModel
    {
        private const string RequiredField = "\"{0}\" is Required";
        private const int CaptionMaxLength = 100;
        private const int ContentMaxLength = 1000;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(CaptionMaxLength)]
        public string Caption { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(ContentMaxLength)]
        public string Content { get; set; }

        public string Quote { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string mId { get; set; }
    }
}

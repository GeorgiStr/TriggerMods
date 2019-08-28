using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerMods.Web.InputModels
{
    public class CommentInputModel
    {
        private const string RequiredField = "\"{0}\" is Required";
        private const int CommentMaxLength = 30;
        private const int CommentMinLength = 5;
        private const string InputLength = "The \"{0}\" must be between {2} and {1} characters.";

        [Required(ErrorMessage = RequiredField)]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength, ErrorMessage = InputLength)]
        public string Content { get; set; }

        public string Id { get; set; }
    }
}

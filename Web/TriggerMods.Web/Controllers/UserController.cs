namespace TriggerMods.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TriggerMods.Services;
    using TriggerMods.Web.ViewModels;

    public class UserController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IModService modService;
        private readonly IPrivateMessageService privateMessageService;

        public UserController(
            ICommentService commentService, 
            IModService modService,
            IPrivateMessageService privateMessageService)
        {
            this.commentService = commentService;
            this.modService = modService;
            this.privateMessageService = privateMessageService;
        }

        public IActionResult UserMods(string id)
        {
            var viewModel = this.modService.GetAllByUserName(id).Select(x => new ModListingViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn,
                Description = x.Description,
                MainPicturePath = x.MainPicturePath,
                UploaderName = x.User.UserName,
                TotalDownloadCount = x.TotalDownloadCount,
                VoteCount = x.VoteCount,
                Visible = x.Visible,
                Game = x.Game.Name,
                GameId = x.GameId,
            }).ToList();

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult UserComments()
        {
            string name = this.User.Identity.Name;

            var viewModel = this.commentService.GetCommentsByUserName(name).Select(x => new CommentsViewModel
            {
                Id = x.Id,
                Content = x.Content,
                CreatedOn = x.CreatedOn,
                UserId = x.UserId,
                UserName = x.User.UserName,
                ModId = x.ModId,
            }).ToList().OrderByDescending(x => x.CreatedOn);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Inbox()
        {
            string name = this.User.Identity.Name;
            InboxViewModel messages = new InboxViewModel();
            var sentPMs = this.privateMessageService
                .GetSentByUserName(name)
                .Select(x => new PrivateMessageViewModel
            {
                Id = x.Id,
                CreatedOn = x. CreatedOn,
                Caption = x.Caption,
                Content = x.Content,
                Quote = x.Quote,
                SenderId = x.SenderId,
                SenderName = x.Sender.UserName,
                ReceiverId = x.ReceiverId,
                ReceiverName = x.Receiver.UserName,

            }).ToList();
            var receivedPMs = this.privateMessageService
                .GetReceivedByUserName(name)
                .Select(x => new PrivateMessageViewModel
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Caption = x.Caption,
                Content = x.Content,
                Quote = x.Quote,
                SenderId = x.SenderId,
                SenderName = x.Sender.UserName,
                ReceiverId = x.ReceiverId,
                ReceiverName = x.Receiver.UserName,

            }).ToList();

            messages.Sent = sentPMs;
            messages.Received = receivedPMs;

            return this.View(messages);
        }
    }
}

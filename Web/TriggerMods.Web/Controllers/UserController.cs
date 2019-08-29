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

        public UserController(ICommentService commentService, IModService modService)
        {
            this.commentService = commentService;
            this.modService = modService;
        }

        [Authorize]
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
    }
}

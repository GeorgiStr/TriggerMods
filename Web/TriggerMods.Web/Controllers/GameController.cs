namespace TriggerMods.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using TriggerMods.Services;
    using TriggerMods.Web.ViewModels;

    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IModService modService;

        public GameController(IGameService gameService, IModService modService)
        {
            this.gameService = gameService;
            this.modService = modService;
        }

        public IActionResult Details(string id, string sortType)
        {
            var viewModel = new ListOfModsViewModel();
            viewModel.Mods = this.modService.GetAllByGameId(id, sortType).Select(x => new ModListingViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Game = x.Game.Name,
                CreatedOn = x.CreatedOn,
                Description = x.Description,
                MainPicturePath = x.MainPicturePath,
                UploaderName = x.User.UserName,
                TotalDownloadCount = x.TotalDownloadCount,
                VoteCount = x.VoteCount,
                Visible = x.Visible,
            }).ToList();

            viewModel.Game = this.gameService.GetGameNameById(id);

            return this.View(viewModel);
        }
    }
}

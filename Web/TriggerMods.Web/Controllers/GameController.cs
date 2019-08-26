using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Services;
using TriggerMods.Web.Areas.Administration.ViewModels.Mod;

namespace TriggerMods.Web.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IModService modService;

        public GameController(IGameService gameService, IModService modService)
        {
            this.gameService = gameService;
            this.modService = modService;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.modService.GetAllByGameId(id).Select(x => new ModListingViewModel
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
            }).ToList();

            return this.View(viewModel);
        }
    }
}

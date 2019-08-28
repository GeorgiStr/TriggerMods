using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Common;
using TriggerMods.Data.Models;
using TriggerMods.Services;
using TriggerMods.Web.Areas.Administration.InputModels.Game;
using TriggerMods.Web.Areas.Administration.ViewModels.Game;

namespace TriggerMods.Web.Areas.Administration.Controllers
{
    public class GameController : AdministrationController
    {
        private readonly IGameService gameService;
        private readonly IPictureService pictureService;

        public GameController(IGameService gameService, IPictureService pictureService)
        {
            this.gameService = gameService;
            this.pictureService = pictureService;
        }

        public IActionResult GameList()
        {
            var viewModel = this.gameService.GetAll().Select(x => new GameListingModel
            {
                Id = x.Id,
                Name = x.Name,
                ModCount = x.ModCount,
                TotalDownloadCount = x.TotalDownloadCount,
            }).ToList();

            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var game = this.gameService.GetGameById(id);
            var model = new EditGameInputModel
            {
                Name = game.Name,
                Id = game.Id,
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGameInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            this.gameService.EditGame(inputModel.Id, inputModel.Name);
            if (inputModel.MainImage != null)
            {
                var imageUrl = await this.pictureService.UploadImage(inputModel.MainImage, GlobalConstants.GAME_PATH_TEMPLATE, inputModel.Name, inputModel.Id);

                this.gameService.AddImageUrl(inputModel.Id, imageUrl);
            }

            return this.RedirectToAction("GameList");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "MainImage")]CreateGameInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var game = new Game
            {
                CreatedOn = DateTime.Now,
                Name = model.Name,
            };

            this.gameService.CreateGame(game);

            if (model.MainImage != null)
            {
                var imageUrl = await this.pictureService.UploadImage(model.MainImage, GlobalConstants.GAME_PATH_TEMPLATE, game.Name,game.Id);

                this.gameService.AddImageUrl(game.Id, imageUrl);
            }

            return this.RedirectToAction(nameof(this.GameList));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Common;
using TriggerMods.Data.Models;
using TriggerMods.Services;
using TriggerMods.Web.InputModels;
using TriggerMods.Web.ViewModels;

namespace TriggerMods.Web.Controllers
{
    public class ModController : BaseController
    {
        private readonly IModService modService;
        private readonly IPictureService pictureService;
        private readonly IUserService userService;
        private readonly IGameService gameService;

        public ModController(IModService modService, IPictureService pictureService, IUserService userService, IGameService gameService)
        {
            this.modService = modService;
            this.pictureService = pictureService;
            this.userService = userService;
            this.gameService = gameService;
        }

        public IActionResult Details(string Id)
        {
            var mod = this.modService.GetById(Id);

            var model = new ModViewModel
            {
                Id = mod.Id,
                Name = mod.Name,
                CreatedOn = mod.CreatedOn,
                Version = mod.Version,
                Description = mod.Description,
                MainPicturePath = mod.MainPicturePath,
                Views = mod.Views,
                TotalDownloadCount = mod.TotalDownloadCount,
                Visible = mod.Visible,
                UserName = mod.User.UserName,
                UserId = mod.UserId,
                GameId = mod.GameId,
                Game = mod.Game.Name,
                Pictures = mod.Pictures.Select(x => x.FilePath).ToList(),
            };

            model.Comments = mod.Comments.Select(x => new CommentsViewModel
            {
                Id = x.Id,
                Content = x.Content,
                CreatedOn = x.CreatedOn,
                UserId = x.UserId,
                UserName = x.User.UserName,
                ModId = x.ModId,
            }).ToList();

            model.Files = mod.Files.Select(x => new FileViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                FileSize = x.FileSize,
                FilePath = x.FilePath,
                Status = x.Status,
                DownlaodCount = x.DownlaodCount,
                ModId = x.ModId,
            }).ToList();
            this.modService.ViewUp(mod.Id);
            return this.View(model);
        }

        [Authorize]
        public IActionResult Create(string Id)
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ModInputModel model)
        {
            var user = this.userService.GetUserByName(this.User.Identity.Name);
            var game = this.gameService.GetGameById(model.GameId);
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var mod = new Mod
            {
                CreatedOn = DateTime.Now,
                Name = model.Name,
                Version = model.Version,
                Description = model.Description,
                User = user,
                Game = game,
            };

            this.modService.Create(mod);
            
            if (model.MainImage != null)
            {
                var imageUrl = await this.pictureService.UploadImage(model.MainImage, GlobalConstants.MOD_PATH_TEMPLATE, mod.Name, mod.Id);

                this.modService.AddImageUrl(mod.Id, imageUrl);
            }

            if (model.MainFile != null)
            {
                var fileUrl = await this.pictureService.UploadFile(model.MainFile, GlobalConstants.File_PATH_TEMPLATE, mod.Name, mod.Id);

                this.modService.AddFileUrl(mod.Id, fileUrl, model.FileName, model.FileDescription, model.MainFile);
            }

            if (model.Gallery != null)
            {
                var fileUrls = await this.pictureService.UploadImages(model.Gallery.ToList(), GlobalConstants.MOD_G_PATH_TEMPLATE, mod.Name, mod.Id);

                this.modService.AddGalleryUrls(mod.Id, fileUrls.ToList());
            }

            return this.Redirect("/");
        }
    }
}

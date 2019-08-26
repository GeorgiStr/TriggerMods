using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Common;
using TriggerMods.Data.Models;
using TriggerMods.Services;
using TriggerMods.Web.InputModels;

namespace TriggerMods.Web.Controllers
{
    public class ModController : BaseController
    {
        private readonly IModService modService;
        private readonly IPictureService pictureService;

        public ModController(IModService modService, IPictureService pictureService)
        {
            this.modService = modService;
            this.pictureService = pictureService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ModInputModel model)
        {
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
            };

            this.modService.Create(mod);

            if (model.MainImage != null)
            {
                var imageUrl = await this.pictureService.UploadImage(model.MainImage, GlobalConstants.GAME_PATH_TEMPLATE, mod.Name, mod.Id);

                this.modService.AddImageUrl(mod.Id, imageUrl);
            }

            return this.Redirect("/");
        }
    }
}

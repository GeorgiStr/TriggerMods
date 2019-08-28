namespace TriggerMods.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using TriggerMods.Services;
    using TriggerMods.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IGameService gameService;

        public HomeController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult Index()
        {
            var viewModel = this.gameService.GetAll().Select(x => new GameViewModel
            {
                Id = x.Id,
                Name = x.Name,
                GamePicturePath = x.GamePicturePath,
                ModCount = x.ModCount,
                TotalDownloadCount = x.TotalDownloadCount,
            }).ToList();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}

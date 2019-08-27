namespace TriggerMods.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IPictureService
    {
        Task<string> UploadImage(IFormFile formImage, string template, string gameName, string gameId);

        Task<string> UploadFile(IFormFile formImage, string template, string gameName, string gameId);

        Task<IEnumerable<string>> UploadImages(IList<IFormFile> formImages, string template, string modName, string modId);
    }
}

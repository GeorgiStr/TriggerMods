namespace TriggerMods.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IPictureService
    {
        Task<string> UploadImage(IFormFile formImage, string template, string gameName, string gameId);

        IEnumerable<string> UploadImages(IList<IFormFile> formImages, int count, string template, int id);
    }
}

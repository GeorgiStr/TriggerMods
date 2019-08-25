using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TriggerMods.Services
{
    public interface IPictureService
    {
        Task<string> UploadImage(IFormFile formImage, string template, string gameName, string gameId);

        IEnumerable<string> UploadImages(IList<IFormFile> formImages, int count, string template, int id);
    }
}

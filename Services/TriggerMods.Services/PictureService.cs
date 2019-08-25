using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TriggerMods.Common;

namespace TriggerMods.Services
{
    public class PictureService : IPictureService
    {

        public async Task<string> UploadImage(IFormFile formImage, string template, string gameName, string gameId)
        {
            string urlName = gameName.Replace(" ",string.Empty).Substring(0,5) + gameId.Substring(0,8);

            var imagePath = string.Format(template, urlName);


            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await formImage.CopyToAsync(stream);
            }

            var imageRoot = imagePath.Replace(GlobalConstants.WWWROOT, string.Empty);

            return imageRoot;
        }

        public IEnumerable<string> UploadImages(IList<IFormFile> formImages, int count, string template, int id)
        {
            throw new NotImplementedException();
        }
    }
}

namespace TriggerMods.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using TriggerMods.Common;

    public class PictureService : IPictureService
    {

        public async Task<string> UploadImage(IFormFile formImage, string template, string gameName, string gameId)
        {
            string urlName = gameName.Replace(" ", string.Empty).Substring(0, 5) + gameId.Substring(0, 8);

            var imagePath = string.Format(template, urlName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await formImage.CopyToAsync(stream);
            }

            var imageRoot = imagePath.Replace(GlobalConstants.WWWROOT, string.Empty);

            return imageRoot;
        }

        public async Task<string> UploadFile(IFormFile formFile, string template, string modName, string modId)
        {
            string urlName = modName.Replace(" ", string.Empty).Substring(0, 5) + modId.Substring(0, 8);
            var fileExt = System.IO.Path.GetExtension(formFile.FileName).Substring(1);

            var filePath = string.Format(template, urlName) + fileExt;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            var imageRoot = filePath.Replace(GlobalConstants.WWWROOT, string.Empty);

            return imageRoot;
        }

        public async Task<IEnumerable<string>> UploadImages(IList<IFormFile> formImages, string template, string modName, string modId)
        {
            var imageUrls = new List<string>();

            for (int i = 0; i < formImages.Count; i++)
            {
                string urlName = modName.Replace(" ", string.Empty).Substring(0, 5) + modId.Substring(0, 8) + $"_{i}";
                var imagePath = string.Format(template, urlName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await formImages[i].CopyToAsync(stream);
                }

                var imageRoot = imagePath.Replace(GlobalConstants.WWWROOT, string.Empty);
                imageUrls.Add(imageRoot);
            }

            return imageUrls;
        }
    }
}

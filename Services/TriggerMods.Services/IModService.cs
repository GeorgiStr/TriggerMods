namespace TriggerMods.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using TriggerMods.Data.Models;

    public interface IModService
    {
        void Create(Mod mod);

        void AddImageUrl(string id, string imageUrl);

        void AddFileUrl(string id, string imageUrl, string fileName, string fileFileDescription, IFormFile MainFile);

        void AddGalleryUrls(string id, List<string> imageUrls);

        void ViewUp(string id);

        void Edit(string id, string name, string version, string description);

        void Delete(string id);

        void RemoveImagesOnEdit(string id);

        void DeleteImages(string id);

        void DeleteFiles(string id);

        Mod GetById(string id);

        IQueryable<Mod> GetAllByGameId(string Id);

        IList<string> GetGalleryUrlsById(string Id);

        IQueryable<Mod> GetAllByUserName(string name);
    }
}

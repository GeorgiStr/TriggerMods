using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data.Models;

namespace TriggerMods.Services
{
    public interface IModService
    {
        void Create(Mod mod);

        void AddImageUrl(string id, string imageUrl);

        void AddFileUrl(string id, string imageUrl, string fileName, string fileFileDescription, IFormFile MainFile);

        void AddGalleryUrls(string id, List<string> imageUrls);

        void ViewUp(string id);

        Mod GetById(string id);

        IQueryable<Mod> GetAllByGameId(string Id);
    }
}

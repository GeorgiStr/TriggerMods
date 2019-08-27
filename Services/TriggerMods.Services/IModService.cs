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

        void AddFileUrl(string id, string imageUrl);

        void AddGalleryUrls(string id, List<string> imageUrls);

        IQueryable<Mod> GetAllByGameId(string Id);
    }
}

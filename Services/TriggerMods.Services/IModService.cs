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

        IQueryable<Mod> GetAllByGameId(string Id);
    }
}

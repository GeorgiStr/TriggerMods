namespace TriggerMods.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class ModService : IModService
    {
        private readonly ApplicationDbContext db;

        public ModService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Mod mod)
        {
            if (mod == null)
            {
                return;
            }

            this.db.Mods.Add(mod);
            this.db.SaveChanges();
        }

        public void AddImageUrl(string id, string imageUrl)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);

            if (mod == null)
            {
                return;
            }

            mod.MainPicturePath = imageUrl;

            this.db.SaveChanges();
        }

        public IQueryable<Mod> GetAllByGameId(string Id)
        {
            return this.db.Mods.Include(x => x.User).Where(x => x.GameId == Id);
        }
    }
}

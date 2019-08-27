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

        public void AddFileUrl(string id, string fileUrl)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);
            var file = new File
            {
                CreatedOn = DateTime.Now,
                FilePath = fileUrl,
                Status = FileStatus.Main,
                Mod = mod,
            };
            if (mod == null)
            {
                return;
            }

            mod.Files.Add(file);

            this.db.SaveChanges();
        }

        public void AddGalleryUrls(string id, List<string> imageUrls)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);

            if (mod == null)
            {
                return;
            }

            foreach (var imageUrl in imageUrls)
            {
                var picture = new Picture
                {
                    CreatedOn = DateTime.Now,
                    FilePath = imageUrl,
                    Mod = mod,
                };
                mod.Pictures.Add(picture);
            }

            this.db.SaveChanges();
        }

        public IQueryable<Mod> GetAllByGameId(string Id)
        {
            return this.db.Mods.Include(x => x.User).Where(x => x.GameId == Id);
        }
    }
}

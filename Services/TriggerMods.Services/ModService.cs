namespace TriggerMods.Services
{
    using Microsoft.AspNetCore.Http;
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
            mod.Game.ModCount++;
            mod.User.ModCount++;
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

        public void AddFileUrl(string id, string fileUrl, string fileName, string fileFileDescription, IFormFile MainFile)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);
            var file = new File
            {
                CreatedOn = DateTime.Now,
                FilePath = fileUrl,
                Name = fileName,
                Description = fileFileDescription,
                FileSize = MainFile.Length / 1024,
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
            return this.db.Mods
                .Include(x => x.User)
                .Where(x => x.GameId == Id);
        }

        public Mod GetById(string id)
        {
            return this.db.Mods
                .Include(x => x.Comments)
                .Include(x => x.Files)
                .Include(x => x.Pictures)
                .Include(x => x.User)
                .Include(x => x.Game)
                .FirstOrDefault(x => x.Id == id);
        }

        public void ViewUp(string id)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);
            mod.Views++;
            db.SaveChanges();
        }

        public IQueryable<Mod> GetAllByUserName(string name)
        {
            return this.db.Mods
                .Where(x => x.User.UserName == name);
        }
    }
}

namespace TriggerMods.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
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

        public void AddFileUrl(string id, string fileUrl, string fileName, string fileFileDescription, long fileLength)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);
            var file = new File
            {
                CreatedOn = DateTime.Now,
                FilePath = fileUrl,
                Name = fileName,
                Description = fileFileDescription,
                FileSize = fileLength / 1024,
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

        public IQueryable<Mod> GetAllByGameId(string Id, string sortType)
        {
            if (sortType == null || sortType.Equals(SortTypes.Date.ToString()))
            {
                return this.db.Mods
                .Include(x => x.User)
                .Where(x => x.GameId == Id).OrderByDescending(x => x.CreatedOn);
            }
            else if (sortType.Equals(SortTypes.Views.ToString()))
            {
                return this.db.Mods
                .Include(x => x.User)
                .Where(x => x.GameId == Id).OrderByDescending(x => x.Views);
            }
            else if (sortType.Equals(SortTypes.Downloads.ToString()))
            {
                return this.db.Mods
                .Include(x => x.User)
                .Where(x => x.GameId == Id).OrderByDescending(x => x.TotalDownloadCount);
            }
            else if (sortType.Equals(SortTypes.Votes.ToString()))
            {
                return this.db.Mods
                .Include(x => x.User)
                .Where(x => x.GameId == Id).OrderByDescending(x => x.VoteCount);
            }

            return null;
        }

        public Mod GetById(string id)
        {
            return this.db.Mods
                .Include(x => x.Files)
                .Include(x => x.Pictures)
                .Include(x => x.User)
                .Include(x => x.Game)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void ViewUp(string id)
        {
            var mod = this.db.Mods.FirstOrDefault(x => x.Id == id);
            mod.Views++;
            this.db.SaveChanges();
        }

        public IQueryable<Mod> GetAllByUserName(string name, string sortType)
        {
            if (sortType == null || sortType.Equals(SortTypes.Date.ToString()))
            {
                return this.db.Mods
                .Where(x => x.User.UserName == name).OrderByDescending(x => x.CreatedOn);
            }
            else if (sortType.Equals(SortTypes.Views.ToString()))
            {
                return this.db.Mods
                .Where(x => x.User.UserName == name).OrderByDescending(x => x.Views);
            }
            else if (sortType.Equals(SortTypes.Downloads.ToString()))
            {
                return this.db.Mods
                .Where(x => x.User.UserName == name).OrderByDescending(x => x.TotalDownloadCount);
            }
            else if (sortType.Equals(SortTypes.Votes.ToString()))
            {
                return this.db.Mods
                .Where(x => x.User.UserName == name).OrderByDescending(x => x.VoteCount);
            }

            return null;
        }

        public IList<string> GetGalleryUrlsById(string Id)
        {
            return this.db.Pictures.Where(x => x.ModId == Id).Select(x => x.FilePath).ToList();
        }

        public void Edit(string id, string name, string version, string description)
        {
            var mod = this.GetById(id);
            mod.Name = name;
            mod.Version = version;
            mod.Description = description;
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var mod = this.GetById(id);
            var game = this.db.Games.FirstOrDefault(x => x.Id == mod.GameId);

            this.DeleteFiles(id);
            this.DeleteImages(id);
            this.DeleteVotes(id);

            game.ModCount--;
            mod.User.ModCount--;

            this.db.Mods.Remove(mod);
            this.db.SaveChanges();
        }

        public void DeleteImages(string id)
        {
            var images = this.db.Pictures.Where(x => x.ModId == id);
            this.db.Pictures.RemoveRange(images);
            this.db.SaveChanges();
        }

        public void DeleteFiles(string id)
        {
            var files = this.db.Files.Where(x => x.ModId == id);
            this.db.Files.RemoveRange(files);
            this.db.SaveChanges();
        }

        public void DeleteVotes(string id)
        {
            var votes = this.db.Votes.Where(x => x.ModId == id);
            this.db.Votes.RemoveRange(votes);
            this.db.SaveChanges();
        }

        public void DownloadsCountUp(string modId, string gameId)
        {
            this.db.Mods.FirstOrDefault(x => x.Id == modId).TotalDownloadCount++;
            this.db.Games.FirstOrDefault(x => x.Id == gameId).TotalDownloadCount++;
            this.db.SaveChanges();
        }
    }
}

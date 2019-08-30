namespace TriggerMods.Services.Tests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;
    using Xunit;

    public class ModServiceTests
    {
        [Fact]
        public void CreatingModShouldIncreaseGameModCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "CreatingModShouldIncreaseGameModCount_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);

            var game = new Game
            {
                ModCount = 0,
            };
            var user = new ApplicationUser
            {
                ModCount = 0,
            };
            dbContext.Users.Add(user);
            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            var mod = new Mod
            {
                Game = game,
                User = user,
            };
                
            modService.Create(mod);

            Assert.Equal(1, mod.Game.ModCount);
        }

        [Fact]
        public void AddImageUrlShouldAddAnImageToMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddImageUrlShouldAddAnImageToMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);

            string imageUrl = "qweqwe";
            
            var mod = new Mod
            {
                MainPicturePath = "asdasd",
            };
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddImageUrl(mod.Id, imageUrl);

            Assert.Equal(imageUrl, mod.MainPicturePath);
        }

        [Fact]
        public void AddFileUrlShouldAddFileToMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddFileUrlShouldAddFileToMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);
            var file = new Mock<IFormFile>();
            var mod = new Mod();
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddFileUrl(mod.Id, null, null, null, 10000000);

            Assert.Single(mod.Files);
        }

        [Fact]
        public void AddGalleryUrlsShouldAddMultipleImagesToMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddGalleryUrlsShouldAddMultipleImagesToMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var urls = new List<string>();
            urls.Add("qqq");
            urls.Add("222");
            urls.Add("rrr");

            var mod = new Mod();
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddGalleryUrls(mod.Id,urls);

            var gallery = mod.Pictures.ToList();

            Assert.Equal(3,gallery.Count);
        }

        [Fact]
        public void GetAllByGameIdShouldReturnAllModsDependingOnSortType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddGalleryUrlsShouldAddMultipleImagesToMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var game = new Game();
            dbContext.Games.Add(game);

            var mod1 = new Mod
            {
                GameId = game.Id,
                Views = 100,
                TotalDownloadCount = 25,
                VoteCount = 50,
            };
            var mod2 = new Mod
            {
                GameId = game.Id,
                Views = 25,
                TotalDownloadCount = 100,
                VoteCount = 50,
            };
            var mod3 = new Mod
            {
                GameId = game.Id,
                Views = 25,
                TotalDownloadCount = 50,
                VoteCount = 100,
            };
            dbContext.Mods.Add(mod1);
            dbContext.Mods.Add(mod2);
            dbContext.Mods.Add(mod3);
            dbContext.SaveChanges();

            var viewsSort = modService.GetAllByGameId(game.Id, "Views").First();
            var votesSort = modService.GetAllByGameId(game.Id, "Votes").First();
            var downloadsSort = modService.GetAllByGameId(game.Id, "Downloads").First();

            Assert.Equal(mod1.Views, viewsSort.Views);
            Assert.Equal(mod2.TotalDownloadCount, downloadsSort.TotalDownloadCount);
            Assert.Equal(mod3.VoteCount, votesSort.VoteCount);
        }

        [Fact]
        public void GetAllByUserNameShouldReturnAllModsDependingOnSortType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "GetAllByUserNameShouldReturnAllModsDependingOnSortType_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var user = new ApplicationUser
            {
                UserName = "Zippo",
            };
            dbContext.Users.Add(user);

            var mod1 = new Mod
            {
                UserId = user.Id,
                Views = 100,
                TotalDownloadCount = 25,
                VoteCount = 50,
            };
            var mod2 = new Mod
            {
                UserId = user.Id,
                Views = 25,
                TotalDownloadCount = 100,
                VoteCount = 50,
            };
            var mod3 = new Mod
            {
                UserId = user.Id,
                Views = 25,
                TotalDownloadCount = 50,
                VoteCount = 100,
            };
            dbContext.Mods.Add(mod1);
            dbContext.Mods.Add(mod2);
            dbContext.Mods.Add(mod3);
            dbContext.SaveChanges();

            var viewsSort = modService.GetAllByUserName(user.UserName, "Views").First();
            var votesSort = modService.GetAllByUserName(user.UserName, "Votes").First();
            var downloadsSort = modService.GetAllByUserName(user.UserName, "Downloads").First();

            Assert.Equal(mod1.Views, viewsSort.Views);
            Assert.Equal(mod2.TotalDownloadCount, downloadsSort.TotalDownloadCount);
            Assert.Equal(mod3.VoteCount, votesSort.VoteCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "GetByIdShouldReturnCorrectMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);
            
            var mod = new Mod
            {
                Name = "DevilSwordNero",
            };
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            var test = modService.GetById(mod.Id);

            Assert.Equal(mod.Name, test.Name);
        }

        [Fact]
        public void ViewUpShouldIncreaseTheViewsOfMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "ViewUpShouldIncreaseTheViewsOfMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);

            var mod = new Mod
            {
                Views = 10,
            };
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.ViewUp(mod.Id);

            Assert.Equal(11, mod.Views);
        }

        [Fact]
        public void GetGalleryUrlsByIdShouldReturnTheImagesOfMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddGalleryUrlsShouldAddMultipleImagesToMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var urls = new List<string>();
            urls.Add("qqq");
            urls.Add("222");
            urls.Add("rrr");

            var mod = new Mod();
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddGalleryUrls(mod.Id, urls);

            var gallery = modService.GetGalleryUrlsById(mod.Id);

            Assert.Equal(3, gallery.Count);
        }

        [Fact]
        public void EditShouldEditNameVersionDescriptionOfMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "EditShouldEditNameVersionDescriptionOfMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var mod = new Mod
            {
                Name = "FlairDante",
                Version = "1.1",
                Description = "Purple Dante",
            };
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            string newName = "FlairDanteV2";
            string newVersion = "2.0";
            string newDescription = "Longer Hair";

            modService.Edit(mod.Id, newName, newVersion, newDescription);

            Assert.Equal(newName, mod.Name);
            Assert.Equal(newVersion, mod.Version);
            Assert.Equal(newDescription, mod.Description);
        }

        [Fact]
        public void DeleteImagesShouldRemoveTheImagesOfMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "RemoveImagesOnEditShouldRemoveTheImagesOfModOnEdit_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);
            var modService = new ModService(dbContext);

            var urls = new List<string>();
            urls.Add("qqq");
            urls.Add("222");
            urls.Add("rrr");

            var mod = new Mod();
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddGalleryUrls(mod.Id, urls);

            modService.DeleteImages(mod.Id);

            Assert.Empty(mod.Pictures);
        }

        [Fact]
        public void DeleteShouldDeleteModAndReduceModCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "DeleteShouldDeleteModAndReduceModCount_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);
            var game = new Game
            {
                ModCount = 10,
            };
            var user = new ApplicationUser
            {
                ModCount = 6,
            };
            dbContext.Users.Add(user);
            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            var mod = new Mod
            {
                Game = game,
                User = user,
            };
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.Delete(mod.Id);

            Assert.Equal(9, game.ModCount);
            Assert.Equal(5, user.ModCount);
        }

        [Fact]
        public void DeleteFilesShouldDeleteFilesFromMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "DeleteFilesShouldDeleteFilesFromMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);

            var mod = new Mod();
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            modService.AddFileUrl(mod.Id, null, null, null, 10000000);
            modService.DeleteFiles(mod.Id);

            Assert.Empty(mod.Files);
        }

        [Fact]
        public void DownloadsCountUpShpouldIncreaseDownloadCountForGameAndMod()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "DownloadsCountUpShpouldIncreaseDownloadCountForGameAndMod_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var modService = new ModService(dbContext);

            var mod = new Mod
            {
                TotalDownloadCount = 100,
            };
            var game = new Game
            {
                TotalDownloadCount = 56
            };
            dbContext.Mods.Add(mod);
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            modService.DownloadsCountUp(mod.Id,game.Id);

            Assert.Equal(101,mod.TotalDownloadCount);
            Assert.Equal(57, game.TotalDownloadCount);
        }

    }
}

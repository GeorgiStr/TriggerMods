using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data;
using TriggerMods.Data.Models;
using Xunit;

namespace TriggerMods.Services.Tests
{
    public class GameServiceTests
    {
        [Fact]
        public void AddImageUrlShouldAddImageToGame()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "AddImageUrlShouldAddImageToGame_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var gameService = new GameService(dbContext);

            var imageUrl = "asdadsasdasdasdasd";

            var game = new Game();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            gameService.AddImageUrl(game.Id, imageUrl);

            Assert.Equal(imageUrl, game.GamePicturePath);
        }

        [Fact]
        public void DeleteGameShouldDeleteGameAndMakeTheirModsUncategorized()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "DeleteGameShouldDeleteGameAndMakeTheirModsUncategorized_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var gameService = new GameService(dbContext);

            var uncategorized = new Game
            {
                Name = "Uncategorized",
            };

            var game = new Game();

            dbContext.Games.Add(game);
            dbContext.Games.Add(uncategorized);
            dbContext.SaveChanges();

            var mod = new Mod
            {
                GameId = game.Id,
            };

            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            gameService.DeleteGame(game.Id);
            var games = dbContext.Games.ToList();

            Assert.Equal(mod.GameId, uncategorized.Id);
            Assert.Single(games);
        }

        [Fact]
        public void EditGameShouldEditGameContentCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "EditGameShouldEditGameContentCorrectly_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var gameService = new GameService(dbContext);

            string newName = "Devil May Cry 5: Special Edition";

            var game = new Game
            {
                Name = "Devil May Cry 5",
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            gameService.EditGame(game.Id, newName);
            
            Assert.Equal(newName, game.Name);
        }
    }
}

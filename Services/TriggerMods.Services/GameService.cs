using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data;
using TriggerMods.Data.Models;

namespace TriggerMods.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext db;

        public GameService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddImageUrl(string id, string imageUrl)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                return;
            }

            game.GamePicturePath = imageUrl;

            this.db.SaveChanges();
        }

        public void CreateGame(Game game)
        {
            if (game == null)
            {
                return;
            }

            this.db.Games.Add(game);
            this.db.SaveChanges();
        }

        public IQueryable<Game> GetAll()
        {
            return this.db.Games;
        }
    }
}

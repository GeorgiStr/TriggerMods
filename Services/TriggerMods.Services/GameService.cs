namespace TriggerMods.Services
{
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

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

        public void EditGame(string id, string name)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);
            game.Name = name;
            db.SaveChanges();
        }

        public IQueryable<Game> GetAll()
        {
            return this.db.Games;
        }

        public Game GetGameById(string Id)
        {
            return this.db.Games.FirstOrDefault(x => x.Id == Id);
        }

        public string GetGameImageUrlById(string id)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);
            return game.GamePicturePath;
        }

        public string GetGameNameById(string id)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);
            return game.Name;
        }
    }
}

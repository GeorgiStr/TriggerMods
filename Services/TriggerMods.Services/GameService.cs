namespace TriggerMods.Services
{
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class GameService : IGameService
    {
        private const string Uncategorized = "Uncategorized";
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

        public void DeleteGame(string id)
        {
            var game = this.GetGameById(id);
            var uncategorized = this.GetGameByName(Uncategorized);

            var mods = this.db.Mods.Where(x => x.GameId == id).ToList();

            for (int i = 0; i < mods.Count; i++)
            {
                mods[i].GameId = uncategorized.Id;
                uncategorized.ModCount++;
            }

            this.db.Games.Remove(game);
            this.db.SaveChanges();
        }

        public void EditGame(string id, string name)
        {
            var game = this.db.Games.FirstOrDefault(x => x.Id == id);
            game.Name = name;
            db.SaveChanges();
        }

        public IQueryable<Game> GetAll(string sortType)
        {
            if(sortType == null || sortType.Equals(SortTypes.Downloads.ToString()))
            {
                return this.db.Games.OrderByDescending(x => x.TotalDownloadCount);
            }
            else if (sortType.Equals(SortTypes.ModCount.ToString()))
            {
                return this.db.Games.OrderByDescending(x => x.ModCount);
            }

            return null;
        }

        public Game GetGameById(string Id)
        {
            return this.db.Games.FirstOrDefault(x => x.Id == Id);
        }

        public Game GetGameByName(string name)
        {
            return this.db.Games.FirstOrDefault(x => x.Name == name);
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

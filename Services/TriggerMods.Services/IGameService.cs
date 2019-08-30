namespace TriggerMods.Services
{
    using System.Linq;

    using TriggerMods.Data.Models;

    public interface IGameService
    {
        void CreateGame(Game game);

        void AddImageUrl(string id, string imageUrl);

        string GetGameImageUrlById(string id);

        string GetGameNameById(string id);

        Game GetGameByName(string name);

        void EditGame(string id, string name);

        void DeleteGame(string id);

        IQueryable<Game> GetAll(string sortType);

        Game GetGameById(string Id);
    }
}

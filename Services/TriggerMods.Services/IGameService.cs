using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data.Models;

namespace TriggerMods.Services
{
    public interface IGameService
    {
        void CreateGame(Game game);

        void AddImageUrl(string id, string imageUrl);

        IQueryable<Game> GetAll();
    }
}

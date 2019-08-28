using Microsoft.AspNetCore.Http;
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

        string GetGameImageUrlById(string id);

        string GetGameNameById(string id);

        void EditGame(string id, string name);

        IQueryable<Game> GetAll();

        Game GetGameById(string Id);
    }
}

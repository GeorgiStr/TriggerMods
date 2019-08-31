namespace TriggerMods.Services
{
    using TriggerMods.Data.Models;

    public interface IVoteService
    {
        void Create(Vote vote);

        void Delete(Vote vote);

        Vote GetVoteOfUser(string modId, string userId);

        bool CheckIfVoted(string modId, string userId);
    }
}

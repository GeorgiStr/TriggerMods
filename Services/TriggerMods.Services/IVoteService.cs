namespace TriggerMods.Services
{
    using TriggerMods.Data.Models;

    public interface IVoteService
    {
        void Create(Vote vote);

        bool CheckIfVoted(string modId, string userId);
    }
}

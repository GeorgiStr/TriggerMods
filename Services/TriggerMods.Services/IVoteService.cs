namespace TriggerMods.Services
{
    using TriggerMods.Data.Models;

    public interface IVoteService
    {
        void Create(Vote vote);
    }
}

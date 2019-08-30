namespace TriggerMods.Services
{
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext db;
        private readonly IModService modService;

        public VoteService(ApplicationDbContext db, IModService modService)
        {
            this.db = db;
            this.modService = modService;
        }

        public void Create(Vote vote)
        {
            var mod = this.modService.GetById(vote.ModId);
            if (vote == null)
            {
                return;
            }

            mod.VoteCount++;

            this.db.Votes.Add(vote);
            this.db.SaveChanges();
        }
    }
}

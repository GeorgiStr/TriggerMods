namespace TriggerMods.Services
{
    using System.Linq;
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

        public bool CheckIfVoted(string modId, string userId)
        {
            var vote = this.db.Votes.FirstOrDefault(x => x.ModId == modId && x.UserId == userId);
            if (vote != null)
            {
                return true;
            }

            return false;
        }

        public void Create(Vote vote)
        {
            var mod = this.modService.GetById(vote.ModId);
            if (vote == null || vote.UserId == null)
            {
                return;
            }

            mod.VoteCount++;

            this.db.Votes.Add(vote);
            this.db.SaveChanges();
        }

        public void Delete(Vote vote)
        {
            var mod = this.modService.GetById(vote.ModId);
            if (vote == null || vote.UserId == null)
            {
                return;
            }

            mod.VoteCount--;

            this.db.Votes.Remove(vote);
            this.db.SaveChanges();
        }

        public Vote GetVoteOfUser(string modId, string userId)
        {
            var vote = this.db.Votes.FirstOrDefault(x => x.ModId == modId && x.UserId == userId);

            return vote;
        }
    }
}

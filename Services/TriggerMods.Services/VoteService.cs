namespace TriggerMods.Services
{
    using System.Linq;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext db;
        private readonly IModService modService;
        private readonly IUserService userService;

        public VoteService(ApplicationDbContext db, IModService modService, IUserService userService)
        {
            this.db = db;
            this.modService = modService;
            this.userService = userService;
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

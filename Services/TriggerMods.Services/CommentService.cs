namespace TriggerMods.Services
{
    using System.Linq;

    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext db;

        public CommentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateComment(Comment comment)
        {
            this.db.Comments.Add(comment);

            var mod = this.db.Mods.FirstOrDefault(x => x.Id == comment.ModId);

            this.db.SaveChanges();
        }

        public IQueryable<Comment> GetCommentsByUserName(string name)
        {
            return this.db.Comments.Where(x => x.User.UserName == name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data;
using TriggerMods.Data.Models;

namespace TriggerMods.Services
{
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

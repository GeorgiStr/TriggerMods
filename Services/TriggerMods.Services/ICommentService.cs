namespace TriggerMods.Services
{
    using System.Linq;

    using TriggerMods.Data.Models;

    public interface ICommentService
    {
        void CreateComment(Comment comment);

        IQueryable<Comment> GetCommentsByUserName(string name);
    }
}

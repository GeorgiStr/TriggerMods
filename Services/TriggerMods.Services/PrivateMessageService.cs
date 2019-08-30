namespace TriggerMods.Services
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class PrivateMessageService : IPrivateMessageService
    {
        private readonly ApplicationDbContext db;

        public PrivateMessageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(PrivateMessage message)
        {
            if (message == null)
            {
                return;
            }

            this.db.PrivateMessages.Add(message);
            this.db.SaveChanges();
        }

        public PrivateMessage GetMessageById(string id)
        {
            return this.db.PrivateMessages
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<PrivateMessage> GetReceivedByUserName(string userName)
        {
            return this.db.PrivateMessages
                .Where(x => x.Receiver.UserName == userName && x.ReceiverHide == false)
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<PrivateMessage> GetSentByUserName(string userName)
        {
            return this.db.PrivateMessages
                .Where(x => x.Sender.UserName == userName && x.SerderHide == false)
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .OrderByDescending(x => x.CreatedOn);
        }

        public void HideReceiver(string id)
        {
            this.db.PrivateMessages.FirstOrDefault(x => x.Id == id).ReceiverHide = true;
            this.db.SaveChanges();
        }

        public void HideSender(string id)
        {
            this.db.PrivateMessages.FirstOrDefault(x => x.Id == id).SerderHide = true;
            this.db.SaveChanges();
        }
    }
}

namespace TriggerMods.Services
{
    using System.Linq;

    using TriggerMods.Data.Models;

    public interface IPrivateMessageService
    {
        void Create(PrivateMessage message);

        void HideSender(string id);

        void HideReceiver(string id);

        PrivateMessage GetMessageById(string id);

        IQueryable<PrivateMessage> GetSentByUserName(string userName);

        IQueryable<PrivateMessage> GetReceivedByUserName(string userName);
    }
}

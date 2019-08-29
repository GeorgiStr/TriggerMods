using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggerMods.Data.Models;
using TriggerMods.Services;
using TriggerMods.Web.InputModels;

namespace TriggerMods.Web.Controllers
{
    public class PrivateMessageController : BaseController
    {
        private readonly IPrivateMessageService privateMessageService;
        private readonly IUserService userService;

        public PrivateMessageController(
            IPrivateMessageService privateMessageService,
            IUserService userService)
        {
            this.privateMessageService = privateMessageService;
            this.userService = userService;
        }

        [Authorize]
        public IActionResult Inbox()
        {

            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {

            return this.View();
        }

        [Authorize]
        public IActionResult Delete(string Id)
        {
            var message = this.privateMessageService.GetMessageById(Id);
            string user = this.User.Identity.Name;

            if (user.Equals(message.Sender.UserName))
            {
                this.privateMessageService.HideSender(message.Id);
            }
            else
            {
                this.privateMessageService.HideReceiver(message.Id);
            }

            return this.RedirectToAction("Inbox", "User");
        }

        [Authorize]
        public IActionResult Reply(string Id)
        {
            string caption = string.Empty;
            var message = this.privateMessageService.GetMessageById(Id);
            if (!message.Caption.StartsWith("RE: "))
            {
                caption = "RE: " + message.Caption;
            }
            else
            {
                caption = message.Caption;
            }

            var model = new PrivateMessageInputModel()
            {
                mId = message.Id,
                Caption = caption,
                Quote = message.Content,
                Receiver = message.Sender.UserName,
                Sender = this.User.Identity.Name,
            };
            int a = 0;
            return this.View("Create", model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PrivateMessageInputModel model)
        {
            var sender = this.userService.GetUserByName(this.User.Identity.Name);
            var receiver = this.userService.GetUserByName(model.Receiver);

            var message = new PrivateMessage
            {
                Caption = model.Caption,
                Content = model.Content,
                Quote = model.Quote,
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                CreatedOn = DateTime.Now,
            };

            this.privateMessageService.Create(message);
            return this.RedirectToAction("Inbox", "User");
            //return this.RedirectToAction("UserMods", "User", new {id = receiver.UserName });
        }
    }
}

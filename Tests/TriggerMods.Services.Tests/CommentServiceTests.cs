using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriggerMods.Data;
using TriggerMods.Data.Models;
using Xunit;

namespace TriggerMods.Services.Tests
{
    public class CommentServiceTests
    {
        [Fact]
        public void GetCommentsByUserNameShouldReturnAllComments()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "GetCommentsByUserNameShouldReturnAllComments_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var commentService = new CommentService(dbContext);

            var user = new ApplicationUser
            {
                UserName = "Gosho",
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var c1 = new Comment
            {
                UserId = user.Id,
                Content = "qweqweqwe",
            };

            var c2 = new Comment
            {
                UserId = user.Id,
                Content = "asdasdasd",
            };

            var c3 = new Comment
            {
                UserId = user.Id,
                Content = "zxczxczxc",
            };

            dbContext.Comments.AddRange(c1,c2,c3);
            dbContext.SaveChanges();

            var comments = commentService.GetCommentsByUserName(user.UserName).ToList();

            Assert.Equal(3, comments.Count);
        }
    }
}

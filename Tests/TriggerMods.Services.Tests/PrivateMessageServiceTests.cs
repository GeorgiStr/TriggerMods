using Microsoft.EntityFrameworkCore;
using System.Linq;
using TriggerMods.Data;
using TriggerMods.Data.Models;
using Xunit;

namespace TriggerMods.Services.Tests
{
    public class PrivateMessageServiceTests
    {
        [Fact]
        public void CreateShouldCreateVote()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "CreateShouldCreateVote_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var privateMessageService = new PrivateMessageService(dbContext);

            var pm = new PrivateMessage();

            privateMessageService.Create(pm);

            var pmTest = dbContext.PrivateMessages.ToList();

            Assert.Single(pmTest);
        }
    }
}

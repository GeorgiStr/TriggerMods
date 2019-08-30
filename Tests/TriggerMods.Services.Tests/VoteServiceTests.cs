using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using TriggerMods.Data;
using TriggerMods.Data.Models;
using Xunit;

namespace TriggerMods.Services.Tests
{
    public class VoteServiceTests
    {
        [Fact]
        public void ShouldCreateVoteEntryAndIncreaseVoteCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "ShouldCreateVoteEntryAndIncreaseVoteCount_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var user = new ApplicationUser();
            var mod = new Mod
            {
                VoteCount = 0,
            };
            dbContext.Users.Add(user);
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            var modServiceMock = new Mock<IModService>();
            modServiceMock.Setup(x => x.GetById(mod.Id)).Returns(mod);
            var voteService = new VoteService(dbContext, modServiceMock.Object);

            var vote = new Vote
            {
                UserId = user.Id,
                ModId = mod.Id,
            };

            voteService.Create(vote);

            var voteTest = dbContext.Votes.ToList();

            Assert.Single(voteTest);
            Assert.Equal(1,mod.VoteCount);
        }

        [Fact]
        public void CheckIfVotedShouldReturnTrueIfUserHasVoted()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "CheckIfVotedShouldReturnTrueIfUserHasVoted_DB")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var user = new ApplicationUser();
            var mod = new Mod
            {
                VoteCount = 0,
            };
            dbContext.Users.Add(user);
            dbContext.Mods.Add(mod);
            dbContext.SaveChanges();

            var modServiceMock = new Mock<IModService>();
            modServiceMock.Setup(x => x.GetById(mod.Id)).Returns(mod);
            var voteService = new VoteService(dbContext, modServiceMock.Object);

            var vote = new Vote
            {
                UserId = user.Id,
                ModId = mod.Id,
            };

            voteService.Create(vote);

            bool check = voteService.CheckIfVoted(mod.Id, user.Id);

            Assert.True(check);
        }
    }
}

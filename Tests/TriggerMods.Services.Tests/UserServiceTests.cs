namespace TriggerMods.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;
    using Xunit;
    public class UserServiceTests
    {
        [Fact]
        public void GetUserByNameShouldReturnCorrectUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "GetUserCompanyByUsername_Users_Database")
                  .Options;

            var dbContext = new ApplicationDbContext(options);

            var usersService = new UserService(dbContext);

            var user = new ApplicationUser
            {
                UserName = "Gosho",
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userTest = usersService.GetUserByName(user.UserName);

            Assert.Equal(user.UserName, userTest.UserName);
        }
    }
}

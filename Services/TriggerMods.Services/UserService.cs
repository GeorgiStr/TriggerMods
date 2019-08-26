namespace TriggerMods.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TriggerMods.Data;
    using TriggerMods.Data.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ApplicationUser GetUserByName(string name)
        {
            return this.db.Users.FirstOrDefault(x => x.UserName == name);
        }
    }
}

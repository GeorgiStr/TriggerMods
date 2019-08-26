namespace TriggerMods.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TriggerMods.Data.Models;

    public interface IUserService
    {
        ApplicationUser GetUserByName(string name);
    }
}

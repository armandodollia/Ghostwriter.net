using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(string userId);
        string GetUserIdByName(string name);
        void CreateUser(ApplicationUser user);
        void DeleteUser(string userId);
        void UpdateUser(ApplicationUser User);
        void Save();
    }
}

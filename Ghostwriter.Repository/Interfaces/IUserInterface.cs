using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    interface IUserInterface : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(string userId);
        void CreateUser(ApplicationUser user);
        void DeleteUser(string userId);
        void UpdateUser(ApplicationUser User);
        void Save();
    }
}

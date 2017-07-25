using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostwriter.Entities.Models;
using Ghostwriter.Entities;

namespace Ghostwriter.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private GhostWriterDbContext context;

        public UserRepository(GhostWriterDbContext context)
        {
            this.context = context;
        }

        public string GetUserIdByName(string name)
        {
            return context.Users
                .Where(u => u.UserName == name)
                .First()
                .Id;
        }

        public void CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(string userId)
        {
            return context.Users
                .Where(u => u.Id == userId)
                .First();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUser User)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

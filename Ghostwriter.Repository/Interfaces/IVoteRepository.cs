using Ghostwriter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    interface IVoteRepository : IDisposable
    {
        IEnumerable<Vote> GetVotes();
        Vote GetVoteById(int voteId);
        void CreateVote(Vote vote);
        void DeleteVote(int voteId);
        void UpdateVote(Vote vote);
        void Save();
    }
}

//using Ghostwriter.Entities;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace Ghostwriter.Repository
//{
//    public class VoteRepository : IVoteRepository, IDisposable
//    {
//        private GhostWriterDbContext context;

//        public VoteRepository(GhostWriterDbContext context)
//        {
//            this.context = context;
//        }

//        public void CreateVote(Vote vote)
//        {
//            context.Votes.Add(vote);
//        }

//        public void DeleteVote(int voteId)
//        {
//            Vote vote = this.GetVoteById(voteId);
//            context.Votes.Remove(vote);
//        }

//        public Vote GetVoteById(int voteId)
//        {
//            return context.Votes.Find(voteId);
//        }

//        public IEnumerable<Vote> GetVotes()
//        {
//            return context.Votes.ToList();
//        }

//        public void Save()
//        {
//            context.SaveChanges();
//        }

//        public void UpdateVote(Vote vote)
//        {
//            context.Entry(vote).State = EntityState.Modified;
//        }

//        #region IDisposable Support
//        private bool disposedValue = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposedValue)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }

//                disposedValue = true;
//            }
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}

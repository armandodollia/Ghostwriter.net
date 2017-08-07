using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ghostwriter.Repository
{
    public class VoteRepository : IVoteRepository, IDisposable
    {
        private GhostWriterDbContext context;

        public VoteRepository(GhostWriterDbContext context)
        {
            this.context = context;
        }

        public void CreateVote(CommentVote commentVote)
        {
            context.CommentVotes.Add(commentVote);
        }

        public void CreateVote(PostVote postVote)
        {
            context.PostVotes.Add(postVote);
        }

        public void DeletePostVote(int voteId)
        {
            PostVote vote = GetPostVoteById(voteId);
            context.PostVotes.Remove(vote);
        }

        public void DeleteCommentVote(int voteId)
        {
            CommentVote vote = GetCommentVoteById(voteId);
            context.CommentVotes.Remove(vote);
        }

        public CommentVote GetCommentVoteById(int voteId)
        {
            return context.CommentVotes.Find(voteId);
        }

        public PostVote GetPostVoteById(int voteId)
        {
            return context.PostVotes.Find(voteId);
        }

        public IEnumerable<CommentVote> GetCommentVotes()
        {
            return context.CommentVotes.ToList();
        }

        public IEnumerable<PostVote> GetPostVotes()
        {
            return context.PostVotes.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateVote(PostVote vote)
        {
            context.Entry(vote).State = EntityState.Modified;
        }

        public void UpdateVote(CommentVote vote)
        {
            context.Entry(vote).State = EntityState.Modified;
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

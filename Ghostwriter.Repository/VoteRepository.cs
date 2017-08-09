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
        private GhostWriterDbContext _context;

        public VoteRepository(GhostWriterDbContext context)
        {
            this._context = context;
        }

        public void CreateVote(CommentVote commentVote)
        {
            _context.CommentVotes.Add(commentVote);
        }

        public void CreateVote(PostVote postVote)
        {
            _context.PostVotes.Add(postVote);
        }

        public void DeletePostVote(int voteId)
        {
            PostVote vote = GetPostVoteById(voteId);
            _context.PostVotes.Remove(vote);
        }

        public void DeleteCommentVote(int voteId)
        {
            CommentVote vote = GetCommentVoteById(voteId);
            _context.CommentVotes.Remove(vote);
        }

        public CommentVote GetCommentVoteById(int voteId)
        {
            return _context.CommentVotes.Where(v => v.Id == voteId).FirstOrDefault();
        }

        public PostVote GetPostVoteById(int voteId)
        {
            return _context.PostVotes.Find(voteId);
        }

        public IEnumerable<CommentVote> GetCommentVotes()
        {
            return _context.CommentVotes.ToList();
        }

        public IEnumerable<PostVote> GetPostVotes()
        {
            return _context.PostVotes.ToList();
        }

        public IEnumerable<PostVote> GetVotesByPostId(int postId)
        {
            return from postVote in _context.PostVotes
                   where postVote.PostId == postId
                   select postVote;
        }

        public IEnumerable<CommentVote> GetVotesByCommentId(int commentId)
        {
            return from commentVote in _context.CommentVotes
                   where commentVote.CommentId == commentId
                   select commentVote;
        }

        public bool PostVoteAreRelated(int postVoteId, string userId)
        {
            PostVote postVote = this.GetPostVoteById(postVoteId);
            return postVote.VoterId == userId;
        }

        public bool CommentVoteAreRelated(int commentVoteId, string userId)
        {
            CommentVote commentVote = this.GetCommentVoteById(commentVoteId);
            return commentVote.VoterId == userId;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateVote(PostVote vote)
        {
            _context.Entry(vote).State = EntityState.Modified;
        }

        public void UpdateVote(CommentVote vote)
        {
            _context.Entry(vote).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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

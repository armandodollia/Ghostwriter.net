using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System.Data.Entity;

namespace Ghostwriter.Repository
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private GhostWriterDbContext _context;

        public CommentRepository(GhostWriterDbContext context)
        {
            this._context = context;
        }

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = this.GetCommentById(commentId);
            _context.Comments.Remove(comment);
        }

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments
                .Where(c => c.Id == commentId)
                .First();
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
        }

        public bool AreRelated(int commentId, string userId)
        {
            Comment comment = this.GetCommentById(commentId);
            return comment.CommenterId == userId;
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            var comments = from c in _context.Comments
                           where c.PostId == postId
                           select new Comment();

            return comments.ToList();
        }

        public IEnumerable<Comment> GetCommentsByCommenterId(string commenterId)
        {
            var comments = from c in _context.Comments
                           where c.CommenterId == commenterId
                           select new Comment();

            return comments;
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

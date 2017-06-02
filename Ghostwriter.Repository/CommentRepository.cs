using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostwriter.Entities;
using System.Data.Entity;

namespace Ghostwriter.Repository
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private GhostWriterDbContext context;

        public CommentRepository(GhostWriterDbContext context)
        {
            this.context = context;
        }

        public void CreateComment(Comment comment)
        {
            context.Comments.Add(comment);
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = this.GetCommentById(commentId);
            context.Comments.Remove(comment);
        }

        public Comment GetCommentById(int commentId)
        {
            return context.Comments.Find(commentId);
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
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

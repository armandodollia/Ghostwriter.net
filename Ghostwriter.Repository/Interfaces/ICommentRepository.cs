using Ghostwriter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    public interface ICommentRepository : IDisposable
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(int commentId);
        void CreateComment(Comment comment);
        void DeleteComment(int commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}

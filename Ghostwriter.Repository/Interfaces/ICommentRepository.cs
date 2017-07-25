using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
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
        IEnumerable<Comment> GetCommentsByPostId(int PostId);
        IEnumerable<Comment> GetCommentsByCommenterId(string CommenterId);
        bool AreRelated(int commentId, string userId);
        Comment GetCommentById(int commentId);
        void CreateComment(Comment comment);
        void DeleteComment(int commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}

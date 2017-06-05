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
        IEnumerable<CommentViewModel> GetComments();
        IEnumerable<CommentViewModel> GetCommentsByPostId(int PostId);
        IEnumerable<CommentViewModel> GetCommentsByCommenterId(string CommenterId);
        Comment GetCommentById(int commentId);
        void CreateComment(Comment comment);
        void DeleteComment(int commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}

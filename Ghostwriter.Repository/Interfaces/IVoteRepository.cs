using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    public interface IVoteRepository : IDisposable
    {
        IEnumerable<CommentVote> GetCommentVotes();
        IEnumerable<PostVote> GetPostVotes();
        IEnumerable<PostVote> GetVotesByPostId(int postId);
        IEnumerable<CommentVote> GetVotesByCommentId(int commentId);
        PostVote GetPostVoteById(int voteId);
        CommentVote GetCommentVoteById(int voteId);
        bool PostVoteAreRelated(int postVoteId, string userId);
        bool CommentVoteAreRelated(int commentVoteId, string userId);
        void CreateVote(CommentVote CommentVote);
        void CreateVote(PostVote PostVote);
        void DeleteCommentVote(int voteId);
        void DeletePostVote(int voteId);
        void UpdateVote(CommentVote vote);
        void UpdateVote(PostVote vote);
        void Save();
    }
}

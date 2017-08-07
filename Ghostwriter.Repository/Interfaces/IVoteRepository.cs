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
        PostVote GetPostVoteById(int voteId);
        CommentVote GetCommentVoteById(int voteId);
        void CreateVote(CommentVote CommentVote);
        void CreateVote(PostVote PostVote);
        void DeleteCommentVote(int voteId);
        void DeletePostVote(int voteId);
        void UpdateVote(CommentVote vote);
        void UpdateVote(PostVote vote);
        void Save();
    }
}

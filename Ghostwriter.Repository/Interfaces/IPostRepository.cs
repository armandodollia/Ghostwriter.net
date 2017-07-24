using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<PostViewModel> GetPosts();
        Post GetPostById(int postId);
        PostViewModel GetPostViewById(int postId);
        PostEditViewModel GetPostToEditById(int postId);
        PostDetailViewModel GetDetailedPostByID(int postId);
        bool AreRelated(int postId, string userId);
        void CreatePost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void UpdateEditPost(PostEditViewModel editPost);
        void Save();
    }
}

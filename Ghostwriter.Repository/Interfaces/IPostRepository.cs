using Ghostwriter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Repository
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int postId);
        void CreatePost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}

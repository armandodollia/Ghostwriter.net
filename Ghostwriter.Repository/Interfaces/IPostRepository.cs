﻿using Ghostwriter.Entities;
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
        IEnumerable<Post> GetPostsByPosterId(string posterId);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPublishedPosts();
        Post GetPostById(int postId);
        bool AreRelated(int postId, string userId);
        void CreatePost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}

using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Ghostwriter.Repository
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private GhostWriterDbContext _context;

        public PostRepository(GhostWriterDbContext context)
        {
            this._context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(int postId)
        {
            Post post = _context.Posts.Find(postId);
            _context.Posts.Remove(post);
        }

        public IEnumerable<Post> GetPostsByPosterId(string posterId)
        {
            return from post in _context.Posts
                   where post.PosterId == posterId
                   select post;
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts
                .Where(p => p.Id == postId)
                .First();
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public bool AreRelated(int postId, string userId)
        {
            Post post = this.GetPostById(postId);
            return post.PosterId == userId;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
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

                this.disposedValue = true;
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

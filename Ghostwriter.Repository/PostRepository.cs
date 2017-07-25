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

        public Post GetPostById(int postId)
        {
            return _context.Posts
                .Where(p => p.Id == postId)
                .First();
        }

        public PostViewModel GetPostViewById(int postId)
        {
            return AutoMapper.Mapper.Map<Post, PostViewModel>(_context.Posts.Find(postId));
        }

        public PostEditViewModel GetPostToEditById(int postId)
        {
            return AutoMapper.Mapper.Map<Post, PostEditViewModel>(_context.Posts.Find(postId));
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
            //return AutoMapper.Mapper.Map<List<Post>, List<PostViewModel>>(_context.Posts.ToList());
        }

        //public PostDetailViewModel GetDetailedPostByID(int postId)
        //{
        //    return _context.Posts
        //        .Where(p => p.Id == postId)
        //        .ProjectTo<PostDetailViewModel>()
        //        .First();
        //}

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

        public void UpdateEditPost(PostEditViewModel model)
        {
            var post = this.GetPostById(model.Id);

            AutoMapper.Mapper.Map(model, post);

            this.UpdatePost(post);
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

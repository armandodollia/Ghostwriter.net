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
        private GhostWriterDbContext context;

        public PostRepository(GhostWriterDbContext context)
        {
            this.context = context;
        }

        public void CreatePost(Post post)
        {
            context.Posts.Add(post);
        }

        public void DeletePost(int postId)
        {
            Post post = context.Posts.Find(postId);
            context.Posts.Remove(post);
        }

        public PostViewModel GetPostById(int postId)
        {
            return context.Posts
                .Where(p => p.Id == postId)
                .ProjectTo<PostViewModel>()
                .First();
            //return AutoMapper.Mapper.Map<Post, PostViewModel>(context.Posts.Find(postId)); 
             
        }

        public IEnumerable<PostViewModel> GetPosts()
        {
            return context.Posts.ProjectTo<PostViewModel>().ToList();
            //return AutoMapper.Mapper.Map<List<Post>, List<PostViewModel>>(context.Posts.ToList());
        }

        public PostDetailViewModel GetDetailedPostByID(int postId)
        {
            return context.Posts
                .Where(p => p.Id == postId)
                .ProjectTo<PostDetailViewModel>()
                .First();
            //return AutoMapper.Mapper.Map<Post, PostDetailViewModel>(context.Posts.Find(postId));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
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

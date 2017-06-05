using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            var post = from p in context.Posts
                       where p.Id == postId
                       select new PostViewModel()
                       {
                           Id = p.Id,
                           Title = p.Title,
                           Body = p.PostBody,
                           PosterId = p.PosterId,
                           IsPublished = p.IsPublished
                       };

            return post.First();
             
        }

        public IEnumerable<PostViewModel> GetPosts()
        {
            return context.Posts.Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.PostBody,
                PosterId = p.PosterId,
                IsPublished = p.IsPublished
            }).ToList();
        }

        public PostDetailViewModel GetDetailedPostByID(int postId)
        {
            var post = from p in context.Posts
                       where p.Id == postId
                       select new PostDetailViewModel()
                       {
                           Id = p.Id,
                           Title = p.Title,
                           Body = p.PostBody,
                           PosterId = p.PosterId,
                           IsPublished = p.IsPublished,
                           Comments = p.Comments.Select(c => new CommentViewModel()
                                      { Id = c.Id,
                                        CommenterId = c.CommenterId,
                                        Body = c.CommentBody
                                      }).ToList()

                       };

            return post.First();
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

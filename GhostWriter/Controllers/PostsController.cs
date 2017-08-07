using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using Ghostwriter.Repository;
using GhostWriter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Controllers
{
    public class PostsController : BaseController
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository, IUserRepository userRepository) : base(userRepository)
        {
            _postRepository = postRepository;
        }

        // GET: Posts
        [HttpGet]
        public ActionResult Index()
        {
            var posts = AutoMapper.Mapper.Map<List<Post>, List<PostViewModel>>(_postRepository.GetPublishedPosts().ToList());
            return View(posts);
        }

        // GET: Posts/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = AutoMapper.Mapper.Map<Post, PostDetailViewModel>(_postRepository.GetPostById(id));
            post.HasVoted = post.Votes.Any(vote => vote.VoterId == GetUserId);
            ViewBag.ShowEditButton = _userRepository.GetUserById(post.PosterId).UserName.Equals(System.Web.HttpContext.Current.User.Identity.Name, StringComparison.OrdinalIgnoreCase);
            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(new PostEditViewModel());
        }

        // POST: Posts/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(PostEditViewModel newPost)
        {
            var post = new Post();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                try
                {
                    AutoMapper.Mapper.Map(newPost, post);
                    post.PosterId = GetUserId;
                    _postRepository.CreatePost(post);
                    _postRepository.Save();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // GET: Posts/Edit/5
        // TODO: make this a PUT
        [Authorize]
        [PostAuthorizationFilter]
        public ActionResult Edit(int id)
        {
            var post = AutoMapper.Mapper.Map<Post, PostEditViewModel>(_postRepository.GetPostById(id));
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [Authorize]
        [PostAuthorizationFilter]
        public ActionResult Edit(PostEditViewModel model)
        {
            try
            {
                var post = _postRepository.GetPostById(model.Id);
                AutoMapper.Mapper.Map(model, post);
                _postRepository.UpdatePost(post);
                _postRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Posts/Publish/5
        [HttpPost]
        [Authorize]
        [PostAuthorizationFilter]
        public ActionResult Publish(int id)
        {
            var postId = id;
            var post = _postRepository.GetPostById(id);
            post.IsPublished ^= true;
            _postRepository.UpdatePost(post);
            _postRepository.Save();
            var postViewModel = AutoMapper.Mapper.Map<Post, PostViewModel>(post);
            return Json(postViewModel);
        }
    }
}

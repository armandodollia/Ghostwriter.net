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
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;

        public PostsController(IPostRepository postRepository, IUserRepository userRepository)
        {
            this._postRepository = postRepository;
            this._userRepository = userRepository;
        }

        // GET: Posts
        [HttpGet]
        public ActionResult Index()
        {
            var posts = AutoMapper.Mapper.Map<List<Post>, List<PostViewModel>>(_postRepository.GetPosts().ToList());
            return View(posts);
        }

        // GET: Posts/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = AutoMapper.Mapper.Map<Post, PostDetailViewModel>(_postRepository.GetPostById(id));
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
                    post.PosterId = _userRepository.GetUserIdByName(HttpContext.User.Identity.Name);
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
        [Authorize]
        [UserAuthorizationFilter]
        public ActionResult Edit(int id)
        {
            var post = AutoMapper.Mapper.Map<Post, PostEditViewModel>(_postRepository.GetPostById(id));
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [Authorize]
        [UserAuthorizationFilter]
        public ActionResult Edit(PostEditViewModel model)
        {
            try
            {
                _postRepository.UpdateEditPost(model);
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
    }
}

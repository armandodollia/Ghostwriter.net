using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository postRepository;

        //public PostsController()
        //{
        //    var context = new GhostWriterDbContext();
        //    postRepository = new PostRepository(context);
        //}

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        // GET: Posts
        [HttpGet]
        public ActionResult Index()
        {
            var posts = postRepository.GetPosts();
            return View(posts);
        }

        // GET: Posts/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var post = postRepository.GetDetailedPostByID(id);
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var post = postRepository.GetPostToEditById(id);
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(PostEditViewModel model)
        {
            try
            {
                postRepository.UpdateEditPost(model);
                postRepository.Save();

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

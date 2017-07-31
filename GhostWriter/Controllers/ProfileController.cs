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
    public class ProfileController : BaseController
    {
        private IPostRepository _postRepository;
        
        public ProfileController(IUserRepository userRepository, IPostRepository postRepository) : base (userRepository)
        {
            _postRepository = postRepository;
        }
        
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            var posts = _postRepository.GetPostsByPosterId(GetUserId);
            var model = AutoMapper.Mapper.Map<IEnumerable<Post>, List<PostViewModel>>(posts);
            return View(model);
        }

        // GET: Profile/Details/5
        public ActionResult Details(string id)
        {
            
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
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

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
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

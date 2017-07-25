using Ghostwriter.Entities.Models;
using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;

        public CommentsController(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
        }
        //// GET: Comments
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Comments/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
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

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            var comment = new CommentViewModel();
            AutoMapper.Mapper.Map(_commentRepository.GetCommentById(id), comment);

            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(CommentViewModel model)
        {
            try
            {
                var comment = _commentRepository.GetCommentById(model.Id);
                AutoMapper.Mapper.Map(model, comment);
                _commentRepository.UpdateComment(comment);
                _commentRepository.Save();

                return RedirectToAction("Details", "Posts", new { id = comment.PostId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
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

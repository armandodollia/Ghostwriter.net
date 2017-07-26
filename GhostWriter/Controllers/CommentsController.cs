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
    public class CommentsController : Controller
    {
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;

        public CommentsController(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
        }

        //// GET: Comments/Create
        //[Authorize]
        //public ActionResult Create()
        //{
        //    var comment = new CommentViewModel();
        //    return View(comment);
        //}

        // POST: Comments/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(CommentViewModel model)
        {
            try
            {
                var comment = new Comment();
                AutoMapper.Mapper.Map(model, comment);
                comment.CommenterId = _userRepository.GetUserIdByName(HttpContext.User.Identity.Name);
                _commentRepository.CreateComment(comment);
                _commentRepository.Save();
                return RedirectToAction("Details", "Posts", new { id = comment.PostId });
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Comments/Edit/5
        [Authorize]
        [CommentAuthorizationFilter]
        public ActionResult Edit(int id)
        {
            var comment = new CommentViewModel();
            AutoMapper.Mapper.Map(_commentRepository.GetCommentById(id), comment);

            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [Authorize]
        [CommentAuthorizationFilter]
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

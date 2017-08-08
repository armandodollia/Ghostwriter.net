using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghostwriter.Repository;
using Ghostwriter.Entities.Models;

namespace GhostWriter.Controllers
{
    public class PostVotesController : BaseController
    {
        private IVoteRepository _voteRepository;

        public PostVotesController(IUserRepository userRepository, IVoteRepository voteRepository) : base(userRepository)
        {
            _voteRepository = voteRepository;
        }

        // POST: Votes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var postId = Convert.ToInt32(collection["PostId"]);
                var vote = new PostVote();
                vote.PostId = postId;
                vote.VoterId = GetUserId;
                _voteRepository.CreateVote(vote);
                _voteRepository.Save();
                return RedirectToAction("Details", "Posts", new { Id = postId });
            }
            catch
            {
                return View();
            }
        }

        // POST: Votes/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                var test = collection;
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

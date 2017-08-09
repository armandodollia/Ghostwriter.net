using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghostwriter.Repository;
using Ghostwriter.Entities.Models;
using GhostWriter.Filters;

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
        [Authorize]
        public ActionResult Create(PostVote vote)
        {
            try
            {
                vote.VoterId = GetUserId;
                _voteRepository.CreateVote(vote);
                _voteRepository.Save();
                return RedirectToAction("Details", "Posts", new { id = vote.PostId });
            }
            catch
            {
                return View();
            }
        }

        // POST: Votes/Delete/5
        [HttpPost]
        [Authorize]
        [PostVoteAuthorizationFilter]
        public ActionResult Delete(int id, PostVote vote)
        {
            try
            {
                _voteRepository.DeletePostVote(vote.Id);
                _voteRepository.Save();

                return RedirectToAction("Details", "Posts", new { id = vote.PostId });
            }
            catch
            {
                return View();
            }
        }
    }
}

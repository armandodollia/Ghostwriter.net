using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ghostwriter.Repository;

namespace GhostWriter.Controllers
{
    public class PostVotesController : BaseController
    {
        private IVoteRepository _voteRepository;

        public PostVotesController(IUserRepository userRepository, IVoteRepository voteRepository) : base(userRepository)
        {
            _voteRepository = voteRepository;
        }

        // GET: Votes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Votes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Votes/Create
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

        // GET: Votes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Votes/Edit/5
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

        // GET: Votes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Votes/Delete/5
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

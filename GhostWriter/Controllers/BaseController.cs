using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ICommentRepository _commentRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IPostRepository _postRepository;
        protected readonly IVoteRepository _voteRepository;

        public BaseController(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
        }

        public BaseController(IPostRepository postRepository, IUserRepository userRepository)
        {
            this._postRepository = postRepository;
            this._userRepository = userRepository;
        }

        public BaseController(IVoteRepository voteRepository, IUserRepository userRepository)
        {
            this._voteRepository = voteRepository;
            this._userRepository = userRepository;
        }

        public string GetUserId { get { return _userRepository.GetUserIdByName(HttpContext.User.Identity.Name); } }
    }
}
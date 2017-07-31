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
    }
}

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
        protected readonly IUserRepository _userRepository;

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetUserId {
            get
            {
                return _userRepository.GetUserIdByName(HttpContext.User.Identity.Name);
            }
        }
    }
}
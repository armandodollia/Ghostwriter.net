using Ghostwriter.Repository;
using Autofac.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Microsoft.Practices.ServiceLocation;

namespace GhostWriter.Filters
{
    public class UserAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public IUserRepository userRepository { get; set; }
        public IPostRepository postRepository { get; set; }

        private bool IsOwner(int postId, string userName)
        {
            string userId = userRepository.GetUserIdByName(userName);
            return postRepository.AreRelated(postId, userId);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var stringPostId = filterContext.Controller.ControllerContext.RouteData.Values["id"].ToString();

            if (int.TryParse(stringPostId, out int postId))
            {
                if (!this.IsOwner(postId, userName))
                {
                    filterContext.Result = new HttpUnauthorizedResult("Unauthorized");
                }

            }
            else
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}
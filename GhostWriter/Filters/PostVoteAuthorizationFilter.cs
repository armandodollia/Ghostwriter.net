using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Filters
{
    public class PostVoteAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public IUserRepository userRepository { get; set; }
        public IVoteRepository voteRepository { get; set; }

        private bool IsOwner(int postVoteId, string userName)
        {
            string userId = userRepository.GetUserIdByName(userName);
            return voteRepository.PostVoteAreRelated(postVoteId, userId);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var stringPostVoteId = filterContext.Controller.ControllerContext.RouteData.Values["id"].ToString();

            if (int.TryParse(stringPostVoteId, out int postVoteId))
            {
                if (!this.IsOwner(postVoteId, userName))
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
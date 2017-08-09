using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Filters
{
    public class CommentVoteAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public IUserRepository userRepository { get; set; }
        public IVoteRepository voteRepository { get; set; }

        private bool IsOwner(int commentVoteId, string userName)
        {
            string userId = userRepository.GetUserIdByName(userName);
            return voteRepository.CommentVoteAreRelated(commentVoteId, userId);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var stringCommentVoteId = filterContext.Controller.ControllerContext.RouteData.Values["id"].ToString();

            if (int.TryParse(stringCommentVoteId, out int commentVoteId))
            {
                if (!this.IsOwner(commentVoteId, userName))
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
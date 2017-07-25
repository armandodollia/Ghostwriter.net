using Ghostwriter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostWriter.Filters
{
    public class CommentAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public IUserRepository userRepository { get; set; }
        public ICommentRepository commentRepository { get; set; }

        private bool IsOwner(int commentId, string userName)
        {
            string userId = userRepository.GetUserIdByName(userName);
            return commentRepository.AreRelated(commentId, userId);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userName = filterContext.HttpContext.User.Identity.Name;
            var stringCommentId = filterContext.Controller.ControllerContext.RouteData.Values["id"].ToString();

            if (int.TryParse(stringCommentId, out int commentId))
            {
                if (!this.IsOwner(commentId, userName))
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
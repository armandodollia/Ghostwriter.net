using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string CommenterId { get; set; }
        public string Body { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities.Models
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PosterId { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}

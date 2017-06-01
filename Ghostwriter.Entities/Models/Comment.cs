using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }


        [Required]
        public string CommentBody { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        [Required]
        public string CommenterId { get; set; }

        [ForeignKey("CommenterId")]
        public virtual ApplicationUser User { get; set; }
    }
}

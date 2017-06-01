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
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]

        public virtual Post Post { get; set; }
    }
}

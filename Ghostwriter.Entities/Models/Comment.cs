using Ghostwriter.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghostwriter.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Required]
        public string CommentBody { get; set; }

        [Required]
        public string CommenterId { get; set; }

        [ForeignKey("CommenterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<CommentVote> CommentVotes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities.Models
{
    public class CommentVote : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Index("VoterAndComment", IsUnique = true, Order = 0)]
        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        [Required, Index("VoterAndComment", IsUnique = true, Order = 1)]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
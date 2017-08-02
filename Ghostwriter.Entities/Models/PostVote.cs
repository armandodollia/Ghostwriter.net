using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities.Models
{
    public class PostVote : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [Required]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
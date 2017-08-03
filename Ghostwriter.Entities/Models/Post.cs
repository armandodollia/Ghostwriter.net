using Ghostwriter.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghostwriter.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            IsPublished = false;
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string PostBody { get; set; }

        public Boolean IsPublished { get; set; }

        [Required]
        public string PosterId { get; set; }

        [ForeignKey("PosterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<PostVote> PostVotes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

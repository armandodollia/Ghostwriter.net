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
    public class Post
    {
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

        public virtual ICollection<Vote> Votes { get; set; }
    }
}

using Ghostwriter.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghostwriter.Entities
{
    public class Vote : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Post Post { get; set; }
    }
}

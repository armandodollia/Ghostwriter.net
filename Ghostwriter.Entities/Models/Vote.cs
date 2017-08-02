using Ghostwriter.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghostwriter.Entities
{
    public class Vote : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        [Column(Order = 2)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Column(Order = 3)]
        public virtual Comment Comment { get; set; }

        [Key]
        [Column(Order = 4)]
        public virtual Post Post { get; set; }
    }
}

using Ghostwriter.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghostwriter.Entities
{
    public partial class GhostWriterDbContext : IdentityDbContext<ApplicationUser>
    {
        public GhostWriterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static GhostWriterDbContext Create()
        {
            return new GhostWriterDbContext();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
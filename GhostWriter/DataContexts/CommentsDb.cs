using Ghostwriter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GhostWriter.DataContexts
{
    public class CommentsDb : DbContext
    {
        public CommentsDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Comment> Comments { get; set; }
    }
}
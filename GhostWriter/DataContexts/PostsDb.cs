using Ghostwriter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GhostWriter.DataContexts
{
    public class PostsDb : DbContext
    {
        public PostsDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
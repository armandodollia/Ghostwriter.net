namespace GhostWriter.Migrations
{
    using Ghostwriter.Entities;
    using Ghostwriter.Entities.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GhostWriterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GhostWriterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //string[] Authors = new string[] { "William Shakespeare", "J-K Rowling", "George R.R. Martin" };

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");


            for (int i = 0; i < 10; i++)
            {
                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = $"test{i}@test.com",
                        Email = $"test{i}@test.com",
                        PasswordHash = password,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = true
                    }
                );
            }

            var users = context.Users.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                context.Posts.AddOrUpdate(p => p.Title,
                    new Post
                    {
                        Title = $"Title {i}",
                        PosterId = users[i].Id,
                        PostBody = "WOW! Look at me! I am text on a screen from a SQL database!"
                    }
                );
            }

            var posts = context.Posts.ToList();

            for (int i = 0; i < posts.Count; i++)
            {
                context.Comments.AddOrUpdate(p => p.CommentBody,
                    new Comment
                    {
                        PostId = posts[i].Id,
                        CommenterId = users[i].Id,
                        CommentBody = "I am a comment, much less toxic than the ones on YouTube!"
                    }
                );
            }
        }
    }
}

namespace GhostWriter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteSplit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        VoterId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VoterId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId)
                .Index(t => t.VoterId);
            
            CreateTable(
                "dbo.CommentVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        VoterId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VoterId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId)
                .Index(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.CommentVotes", "VoterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostVotes", "CommentId", "dbo.Posts");
            DropForeignKey("dbo.PostVotes", "VoterId", "dbo.AspNetUsers");
            DropIndex("dbo.CommentVotes", new[] { "VoterId" });
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.PostVotes", new[] { "VoterId" });
            DropIndex("dbo.PostVotes", new[] { "CommentId" });
            DropTable("dbo.CommentVotes");
            DropTable("dbo.PostVotes");
        }
    }
}

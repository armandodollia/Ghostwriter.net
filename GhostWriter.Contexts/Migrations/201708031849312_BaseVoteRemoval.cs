namespace GhostWriter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseVoteRemoval : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "VoterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Votes", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Votes", new[] { "VoterId" });
            DropIndex("dbo.Votes", new[] { "Comment_Id" });
            DropIndex("dbo.Votes", new[] { "Post_Id" });
            DropTable("dbo.Votes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        Comment_Id = c.Int(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Votes", "Post_Id");
            CreateIndex("dbo.Votes", "Comment_Id");
            CreateIndex("dbo.Votes", "VoterId");
            AddForeignKey("dbo.Votes", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Votes", "Comment_Id", "dbo.Comments", "Id");
            AddForeignKey("dbo.Votes", "VoterId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

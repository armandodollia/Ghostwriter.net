namespace GhostWriter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompositeIndeces : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.CommentVotes", new[] { "VoterId" });
            DropIndex("dbo.PostVotes", new[] { "CommentId" });
            DropIndex("dbo.PostVotes", new[] { "VoterId" });
            CreateIndex("dbo.CommentVotes", new[] { "CommentId", "VoterId" }, unique: true, name: "VoterAndComment");
            CreateIndex("dbo.PostVotes", new[] { "CommentId", "VoterId" }, unique: true, name: "VoterAndPost");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostVotes", "VoterAndPost");
            DropIndex("dbo.CommentVotes", "VoterAndComment");
            CreateIndex("dbo.PostVotes", "VoterId");
            CreateIndex("dbo.PostVotes", "CommentId");
            CreateIndex("dbo.CommentVotes", "VoterId");
            CreateIndex("dbo.CommentVotes", "CommentId");
        }
    }
}

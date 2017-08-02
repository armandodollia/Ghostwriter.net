namespace GhostWriter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteSeparation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Votes", newName: "CommentVotes");
            DropForeignKey("dbo.Votes", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Votes", "Post_Id", "dbo.Posts");
            DropIndex("dbo.CommentVotes", new[] { "Comment_Id" });
            DropIndex("dbo.CommentVotes", new[] { "Post_Id" });
            RenameColumn(table: "dbo.CommentVotes", name: "Comment_Id", newName: "CommentId");
            RenameColumn(table: "dbo.PostVotes", name: "Post_Id", newName: "PostId");
            CreateTable(
                "dbo.PostVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        VoterId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.VoterId);
            
            AlterColumn("dbo.CommentVotes", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CommentVotes", "CommentId");
            AddForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
            DropColumn("dbo.CommentVotes", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentVotes", "Post_Id", c => c.Int());
            DropForeignKey("dbo.PostVotes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropIndex("dbo.PostVotes", new[] { "VoterId" });
            DropIndex("dbo.PostVotes", new[] { "PostId" });
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            AlterColumn("dbo.CommentVotes", "CommentId", c => c.Int());
            DropTable("dbo.PostVotes");
            RenameColumn(table: "dbo.PostVotes", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.CommentVotes", name: "CommentId", newName: "Comment_Id");
            CreateIndex("dbo.CommentVotes", "Post_Id");
            CreateIndex("dbo.CommentVotes", "Comment_Id");
            AddForeignKey("dbo.Votes", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Votes", "Comment_Id", "dbo.Comments", "Id");
            RenameTable(name: "dbo.CommentVotes", newName: "Votes");
        }
    }
}

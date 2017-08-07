namespace GhostWriter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPostVoteForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PostVotes", name: "CommentId", newName: "PostId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.PostVotes", name: "PostId", newName: "CommentId");
        }
    }
}

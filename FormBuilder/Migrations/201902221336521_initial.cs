namespace FormBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomForm",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "date"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstMidName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomForm", "UserId", "dbo.User");
            DropIndex("dbo.CustomForm", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.CustomForm");
        }
    }
}

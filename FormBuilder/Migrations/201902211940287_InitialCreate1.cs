namespace FormBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormItem",
                c => new
                    {
                        FormItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Required = c.Boolean(nullable: false),
                        DataType = c.String(nullable: false),
                        CustomForm_FormId = c.Int(),
                    })
                .PrimaryKey(t => t.FormItemID)
                .ForeignKey("dbo.CustomForm", t => t.CustomForm_FormId)
                .Index(t => t.CustomForm_FormId);
            
            CreateTable(
                "dbo.CustomForm",
                c => new
                    {
                        FormId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false, storeType: "date"),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FormId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomForm", "User_Id", "dbo.User");
            DropForeignKey("dbo.FormItem", "CustomForm_FormId", "dbo.CustomForm");
            DropIndex("dbo.CustomForm", new[] { "User_Id" });
            DropIndex("dbo.FormItem", new[] { "CustomForm_FormId" });
            DropTable("dbo.CustomForm");
            DropTable("dbo.FormItem");
        }
    }
}

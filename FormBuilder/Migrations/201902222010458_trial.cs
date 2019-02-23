namespace FormBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomForm", "Fields", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomForm", "Fields");
        }
    }
}

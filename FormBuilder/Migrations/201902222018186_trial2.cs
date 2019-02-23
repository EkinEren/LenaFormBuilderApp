namespace FormBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomForm", "Fields");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomForm", "Fields", c => c.String());
        }
    }
}

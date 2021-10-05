namespace BT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creat_role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
        }
    }
}

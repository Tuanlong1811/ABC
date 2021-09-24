namespace BT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Description", c => c.String());
            AddColumn("dbo.People", "Sex", c => c.String());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "Sex");
            DropColumn("dbo.People", "Description");
        }
    }
}

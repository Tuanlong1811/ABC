namespace BT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PerSonID = c.String(nullable: false, maxLength: 128),
                        PsName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PerSonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}

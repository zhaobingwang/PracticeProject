namespace Project.Framework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        CreateDate = c.DateTime(precision: 0),
                        ModifyDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
        }
    }
}

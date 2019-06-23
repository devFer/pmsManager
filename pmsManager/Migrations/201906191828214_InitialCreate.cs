namespace pmsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Pms",
                c => new
                    {
                        pmsId = c.Int(nullable: false, identity: true),
                        pmsName = c.String(),
                        numberOfManagers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pmsId);
            
            CreateTable(
                "dbo.ImpExpAssociateds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        isExport = c.Boolean(nullable: false),
                        isImport = c.Boolean(nullable: false),
                        Pms_pmsId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pms", t => t.Pms_pmsId)
                .Index(t => t.Pms_pmsId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ImpExpAssociateds", new[] { "Pms_pmsId" });
            DropForeignKey("dbo.ImpExpAssociateds", "Pms_pmsId", "dbo.Pms");
            DropTable("dbo.ImpExpAssociateds");
            DropTable("dbo.Pms");
            DropTable("dbo.UserProfile");
        }
    }
}

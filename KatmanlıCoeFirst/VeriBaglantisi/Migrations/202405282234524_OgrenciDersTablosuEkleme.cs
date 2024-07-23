namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OgrenciDersTablosuEkleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OgrenciDersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgrenciID = c.Int(nullable: false),
                        DersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dersler", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrenciler", t => t.OgrenciID, cascadeDelete: true)
                .Index(t => t.OgrenciID)
                .Index(t => t.DersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciDersler", "OgrenciID", "dbo.Ogrenciler");
            DropForeignKey("dbo.OgrenciDersler", "DersID", "dbo.Dersler");
            DropIndex("dbo.OgrenciDersler", new[] { "DersID" });
            DropIndex("dbo.OgrenciDersler", new[] { "OgrenciID" });
            DropTable("dbo.OgrenciDersler");
        }
    }
}

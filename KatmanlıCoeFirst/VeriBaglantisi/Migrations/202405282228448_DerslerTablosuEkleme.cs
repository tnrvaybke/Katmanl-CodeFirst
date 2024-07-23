namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DerslerTablosuEkleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dersKodu = c.String(nullable: false, maxLength: 20),
                        dersAdi = c.String(nullable: false, maxLength: 100),
                        akts = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
           
            
        }
        
        public override void Down()
        {
            
            DropTable("dbo.Dersler");
        }
    }
}

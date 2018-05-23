namespace Sawlux.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdRestaurante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurante", t => t.IdRestaurante, cascadeDelete: true)
                .Index(t => t.IdRestaurante);
            
            CreateTable(
                "dbo.Restaurante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prato", "IdRestaurante", "dbo.Restaurante");
            DropIndex("dbo.Prato", new[] { "IdRestaurante" });
            DropTable("dbo.Restaurante");
            DropTable("dbo.Prato");
        }
    }
}

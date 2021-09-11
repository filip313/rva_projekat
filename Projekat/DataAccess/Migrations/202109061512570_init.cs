namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        DatumVremePocetka = c.DateTime(nullable: false),
                        DatumVremeZavrsetka = c.DateTime(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Planner_PlannerId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Planners", t => t.Planner_PlannerId)
                .Index(t => t.Planner_PlannerId);
            
            CreateTable(
                "dbo.Planners",
                c => new
                    {
                        PlannerId = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        Naziv = c.String(),
                        DatumPocetka = c.DateTime(nullable: false),
                        DatumZavrsetka = c.DateTime(nullable: false),
                        PlanerCreator_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PlannerId)
                .ForeignKey("dbo.Users", t => t.PlanerCreator_UserId)
                .Index(t => t.PlanerCreator_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planners", "PlanerCreator_UserId", "dbo.Users");
            DropForeignKey("dbo.Events", "Planner_PlannerId", "dbo.Planners");
            DropIndex("dbo.Planners", new[] { "PlanerCreator_UserId" });
            DropIndex("dbo.Events", new[] { "Planner_PlannerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Planners");
            DropTable("dbo.Events");
        }
    }
}

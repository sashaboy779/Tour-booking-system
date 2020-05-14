namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Resort_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resorts", t => t.Resort_Id)
                .Index(t => t.Resort_Id);
            
            CreateTable(
                "dbo.TourVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TouristsNumber = c.Int(nullable: false),
                        PersonPrice = c.Double(nullable: false),
                        TicketsNumber = c.Int(nullable: false),
                        RoomType = c.Int(nullable: false),
                        Food = c.Int(nullable: false),
                        Travel_Id = c.Int(),
                        Tour_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Travels", t => t.Travel_Id)
                .ForeignKey("dbo.Tours", t => t.Tour_Id)
                .Index(t => t.Travel_Id)
                .Index(t => t.Tour_Id);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsIncluded = c.Boolean(nullable: false),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        DepartureCity = c.String(),
                        ArrivalCity = c.String(),
                        TransportType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "Resort_Id", "dbo.Resorts");
            DropForeignKey("dbo.TourVariants", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.TourVariants", "Travel_Id", "dbo.Travels");
            DropIndex("dbo.TourVariants", new[] { "Tour_Id" });
            DropIndex("dbo.TourVariants", new[] { "Travel_Id" });
            DropIndex("dbo.Tours", new[] { "Resort_Id" });
            DropTable("dbo.Travels");
            DropTable("dbo.TourVariants");
            DropTable("dbo.Tours");
            DropTable("dbo.Resorts");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRalationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tours", "Resort_Id", "dbo.Resorts");
            DropForeignKey("dbo.TourVariants", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.Tours", new[] { "Resort_Id" });
            DropIndex("dbo.TourVariants", new[] { "Tour_Id" });
            RenameColumn(table: "dbo.Tours", name: "Resort_Id", newName: "ResortId");
            RenameColumn(table: "dbo.TourVariants", name: "Tour_Id", newName: "TourId");
            AlterColumn("dbo.Tours", "ResortId", c => c.Int(nullable: false));
            AlterColumn("dbo.TourVariants", "TourId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tours", "ResortId");
            CreateIndex("dbo.TourVariants", "TourId");
            AddForeignKey("dbo.Tours", "ResortId", "dbo.Resorts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TourVariants", "TourId", "dbo.Tours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourVariants", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Tours", "ResortId", "dbo.Resorts");
            DropIndex("dbo.TourVariants", new[] { "TourId" });
            DropIndex("dbo.Tours", new[] { "ResortId" });
            AlterColumn("dbo.TourVariants", "TourId", c => c.Int());
            AlterColumn("dbo.Tours", "ResortId", c => c.Int());
            RenameColumn(table: "dbo.TourVariants", name: "TourId", newName: "Tour_Id");
            RenameColumn(table: "dbo.Tours", name: "ResortId", newName: "Resort_Id");
            CreateIndex("dbo.TourVariants", "Tour_Id");
            CreateIndex("dbo.Tours", "Resort_Id");
            AddForeignKey("dbo.TourVariants", "Tour_Id", "dbo.Tours", "Id");
            AddForeignKey("dbo.Tours", "Resort_Id", "dbo.Resorts", "Id");
        }
    }
}

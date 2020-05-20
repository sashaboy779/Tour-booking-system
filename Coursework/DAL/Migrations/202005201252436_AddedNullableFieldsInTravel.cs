namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableFieldsInTravel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Travels", "Departure", c => c.DateTime());
            AlterColumn("dbo.Travels", "TransportType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Travels", "TransportType", c => c.Int(nullable: false));
            AlterColumn("dbo.Travels", "Departure", c => c.DateTime(nullable: false));
        }
    }
}

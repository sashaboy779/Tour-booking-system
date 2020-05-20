namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Travels", "Departure", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Travels", "Departure", c => c.DateTime());
        }
    }
}

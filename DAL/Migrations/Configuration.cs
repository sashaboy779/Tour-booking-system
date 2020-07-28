namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using EF;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}

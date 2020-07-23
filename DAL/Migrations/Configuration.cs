namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Entity;
    using System.Collections.Generic;
    using DAL.EF;
    using Microsoft.AspNet.Identity;
    using DAL.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}

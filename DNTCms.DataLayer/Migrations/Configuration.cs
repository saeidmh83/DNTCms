using System.Data.Entity.Migrations;
using DNTCms.DataLayer.Context;


namespace DNTCms.DataLayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

    }
}

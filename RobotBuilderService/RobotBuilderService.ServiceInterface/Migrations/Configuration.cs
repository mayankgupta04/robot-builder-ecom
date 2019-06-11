namespace RobotBuilderService.ServiceInterface.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RobotBuilderService.ServiceInterface.Context.RobotBuilderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RobotBuilderService.ServiceInterface.Context.RobotBuilderContext";
        }

        protected override void Seed(RobotBuilderService.ServiceInterface.Context.RobotBuilderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

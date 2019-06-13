using System.Data.Entity;
using RobotBuilderService.ServiceInterface.Context.Entities;

namespace RobotBuilderService.ServiceInterface.Context
{
    class RobotBuilderContext : DbContext
    {
        public RobotBuilderContext()
            : base("name=RobotBuilderEcom")
        {
        }

        public virtual DbSet<CartBot> Robots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RobotBuilderContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

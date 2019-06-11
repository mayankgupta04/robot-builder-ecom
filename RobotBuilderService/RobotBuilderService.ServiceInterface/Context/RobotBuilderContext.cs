using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RobotBuilderService.ServiceInterface.Data.Entities;

namespace RobotBuilderService.ServiceInterface.Context
{
    class RobotBuilderContext : DbContext
    {
        public RobotBuilderContext()
            : base("name=RobotBuilderEcom")
        {
        }

        public virtual DbSet<RobotPart> Robot { get; set; }
    }
}

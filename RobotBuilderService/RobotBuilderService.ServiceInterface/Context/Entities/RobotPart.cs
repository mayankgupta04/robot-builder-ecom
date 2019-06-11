using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBuilderService.ServiceInterface.Data.Entities
{
    public partial class RobotPart
    {
        //[Required]
        public virtual int Id { get; set; }
        //[Required]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }
        //[Required]
        public virtual string Type { get; set; }
        // [Required]
        public virtual double Cost { get; set; }
    }
}

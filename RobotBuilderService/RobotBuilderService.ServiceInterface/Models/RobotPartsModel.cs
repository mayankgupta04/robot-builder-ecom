using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBuilderService.ServiceInterface.Models
{
    class RobotPartsModel
    {
        public List<RobotPart> heads { get; set; }
        public List<RobotPart> arms { get; set; }
        public List<RobotPart> torsos { get; set; }
        public List<RobotPart> bases { get; set; }
    }
}

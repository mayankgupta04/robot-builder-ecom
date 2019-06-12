using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBuilderService.ServiceInterface.Models
{
    class RobotPart
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string src { get; set; }
        public decimal cost { get; set; }
        public bool onSale { get; set; }

    }
}

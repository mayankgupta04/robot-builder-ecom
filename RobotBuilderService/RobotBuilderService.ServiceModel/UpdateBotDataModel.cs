using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/updatebot", "POST")]
    public class UpdateBotDataModel : IReturn<UpdateBotDataModelResponse>
    {
        public int CartBotId { get; set; }
        public int HeadId { get; set; }
        public int LeftArmId { get; set; }
        public int RightArmId { get; set; }
        public int TorsoId { get; set; }
        public int BaseId { get; set; }
        public decimal Cost { get; set; }
    }

    public class UpdateBotDataModelResponse
    {
        public int Id { get; set; }
    }
}
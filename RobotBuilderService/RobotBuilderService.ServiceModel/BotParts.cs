using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/botparts", "GET")]
    public class BotParts : IReturn<BotPartsResponse>
    {
    }

    public class BotPartsResponse
    {
        public object BotPartsResult { get; set; }
    }
}
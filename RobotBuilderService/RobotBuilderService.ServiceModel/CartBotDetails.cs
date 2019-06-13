using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/getbotbyid", "POST")]
    public class CartBotDetails : IReturn<CartBotDetailsResponse>
    {
        public int CartBotId { get; set; }
    }

    public class CartBotDetailsResponse
    {
        public object CartBotDetails { get; set; }
    }
}
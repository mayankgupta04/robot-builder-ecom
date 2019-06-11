using ServiceStack;
using RobotBuilderService.ServiceModel;
using RobotBuilderService.ServiceInterface.Context;
using System.Linq;

namespace RobotBuilderService.ServiceInterface
{
    public class BotServices : Service
    {
        public object Get(BotParts request)
        {
            RobotBuilderContext obj = new RobotBuilderContext();
            var list = obj.Robot.ToList();
            return new BotPartsResponse { BotPartsResult = { } };
        }
    }
}
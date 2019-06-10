using ServiceStack;
using RobotBuilderService.ServiceModel;

namespace RobotBuilderService.ServiceInterface
{
    public class BotServices : Service
    {
        public object Get(BotParts request)
        {
            return new BotPartsResponse { BotPartsResult = { } };
        }
    }
}
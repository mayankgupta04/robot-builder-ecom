using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/harddeletebot", "DELETE")]
    public class HardDeleteBot : IReturn<HardDeleteBotResponse>
    {
        public int CartBotId { get; set; }
    }

    public class HardDeleteBotResponse
    {
        public bool IsSuccess { get; set; }
    }
}
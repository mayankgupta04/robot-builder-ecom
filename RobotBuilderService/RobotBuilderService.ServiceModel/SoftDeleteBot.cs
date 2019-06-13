using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/softdeletebot", "DELETE")]
    public class SoftDeleteBot : IReturn<SoftDeleteBotResponse>
    {
        public int CartBotId { get; set; }
    }

    public class SoftDeleteBotResponse
    {
        public bool IsSuccess { get; set; }
    }
}
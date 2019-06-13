
namespace RobotBuilderService.ServiceInterface.Context.Entities
{
    public class CartBot
    {
        public CartBot()
        {
        }

        public CartBot(int headId, int leftArmId, int rightArmId, int torsoId, int baseId, decimal cost)
        {
            HeadId = headId;
            LeftArmId = leftArmId;
            RightArmId = rightArmId;
            TorsoId = torsoId;
            BaseId = baseId;
            Cost = cost;
            IsActive = true;
        }

        public int CartBotId { get; set; }
        public int HeadId { get; set; }
        public int LeftArmId { get; set; }
        public int RightArmId { get; set; }
        public int TorsoId { get; set; }
        public int BaseId { get; set; }
        public bool IsActive { get; set; }
        public decimal Cost { get; set; }
    }
}

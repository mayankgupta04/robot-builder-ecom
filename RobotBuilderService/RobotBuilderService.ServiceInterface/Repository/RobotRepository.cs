using RobotBuilderService.ServiceInterface.Context;
using RobotBuilderService.ServiceInterface.Context.Entities;
using RobotBuilderService.ServiceModel;
using ServiceStack;
using System.Linq;

namespace RobotBuilderService.ServiceInterface.Repository
{
    public class RobotRepository
    {
        private RobotBuilderContext _dbContext;

        public RobotRepository()
        {
            _dbContext = new RobotBuilderContext();
        }

        // Add a method to save item in BotCart        
        public int AddNewBot(BotDataModel model)
        {
            var newBot = new CartBot(model.HeadId, model.LeftArmId, model.RightArmId, model.TorsoId, model.BaseId, model.Cost);
            _dbContext.Robots.Add(newBot);
            _dbContext.SaveChanges();

            return newBot.CartBotId;
        }

        public void UpdateBot(UpdateBotDataModel model)
        {
            var botToUpdate = _dbContext.Robots.Find(model.CartBotId);
            botToUpdate.BaseId = model.BaseId;
            botToUpdate.Cost = model.Cost;
            botToUpdate.HeadId = model.HeadId;
            botToUpdate.LeftArmId = model.LeftArmId;
            botToUpdate.RightArmId = model.RightArmId;
            botToUpdate.TorsoId = model.TorsoId;

            _dbContext.SaveChanges();
        }

        public void SoftDeleteBot(SoftDeleteBot model)
        {
            var robotToSoftDelete = _dbContext.Robots.Find(model.CartBotId);
            robotToSoftDelete.IsActive = false;
            _dbContext.SaveChanges();
        }

        public void HardDeleteBot(HardDeleteBot model)
        {
            var robotToHardDelete = _dbContext.Robots.Find(model.CartBotId);
            _dbContext.Robots.Remove(robotToHardDelete);
            _dbContext.SaveChanges();
        }

        public object GetCartBotById(CartBotDetails model)
        {
            return _dbContext.Robots.Find(model.CartBotId);
        }

        public object GetCartBots()
        {
            return _dbContext.Robots.ToList();
        }
    }
}

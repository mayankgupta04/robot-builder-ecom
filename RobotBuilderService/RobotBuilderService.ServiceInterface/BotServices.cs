using ServiceStack;
using RobotBuilderService.ServiceModel;
using System.IO;
using RobotBuilderService.ServiceInterface.Models;
using Newtonsoft.Json;
using RobotBuilderService.ServiceInterface.Repository;

namespace RobotBuilderService.ServiceInterface
{
    public class BotServices : Service
    {
        private readonly RobotRepository _repo;
        public BotServices()
        {
            _repo = new RobotRepository();
        }

        public object Get(BotParts request)
        {
            return new BotPartsResponse { BotPartsResult = GetBotPartsJsonData() };
        }

        public int Post(BotDataModel request)
        {
            return _repo.AddNewBot(request);
        }

        public void Post(UpdateBotDataModel request)
        {
            _repo.UpdateBot(request);
        }

        public void Delete(SoftDeleteBot request)
        {
            _repo.SoftDeleteBot(request);
        }

        public void Delete(HardDeleteBot request)
        {
            _repo.HardDeleteBot(request);
        }

        public object Get(CartItems request)
        {
            return new CartItemsResponse { CartItems = GetCartBotsJsonData() };
        }

        public object Post(CartBotDetails request)
        {
            return new CartBotDetailsResponse { CartBotDetails = GetCartBotsDetailsById(request) };
        }

        private object GetCartBotsDetailsById(CartBotDetails request)
        {
            return _repo.GetCartBotById(request);
        }

        private object GetBotPartsJsonData()
        {
            using (StreamReader r = new StreamReader("../../JSON Data/bot-parts.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<RobotPartsModel>(json);
            }
        }

        private object GetCartBotsJsonData()
        {
            return _repo.GetCartBots();
        }
    }
}
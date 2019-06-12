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

        public long Post(BotDataModel request)
        {
            return 1L;
        }

        public object Get(CartItems request)
        {
            return new CartItemsResponse { CartItems = null };
        }

        private object GetBotPartsJsonData()
        {
            using (StreamReader r = new StreamReader("../../JSON Data/bot-parts.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<RobotPartsModel>(json);
            }
        }
    }
}
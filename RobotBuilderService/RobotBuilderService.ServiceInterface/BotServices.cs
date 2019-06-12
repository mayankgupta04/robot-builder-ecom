using ServiceStack;
using RobotBuilderService.ServiceModel;
using System.IO;
using RobotBuilderService.ServiceInterface.Models;
using Newtonsoft.Json;

namespace RobotBuilderService.ServiceInterface
{
    public class BotServices : Service
    {
        public object Get(BotParts request)
        {
            return new BotPartsResponse { BotPartsResult = GetBotPartsJsonData() };
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
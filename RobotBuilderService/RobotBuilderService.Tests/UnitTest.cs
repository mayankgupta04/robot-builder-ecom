using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using RobotBuilderService.ServiceInterface;
using RobotBuilderService.ServiceModel;

namespace RobotBuilderService.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<BotServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        [Test]
        public void Can_call_MyServices()
        {
            var service = appHost.Container.Resolve<BotServices>();

            var response = (BotPartsResponse)service.Get(new BotParts());

            Assert.That(response.BotPartsResult, Is.EqualTo("Hello, World!"));
        }
    }
}

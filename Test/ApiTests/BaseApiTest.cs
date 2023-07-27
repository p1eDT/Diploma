using Allure.Commons;
using Api.RestCore;
using Core;
using Core.Configuration;
using Core.Selenium;
using NUnit.Allure.Core;

namespace Api.Tests
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected BaseApiClient apiClient;
        private AllureLifecycle allure;
        protected TestLog logger;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            apiClient = new BaseApiClient(AppConfiguration.Api.BaseUrl);
            allure = AllureLifecycle.Instance;
            logger = new TestLog();
        }

        [SetUp]
        public void StartLog()
        {
            TestLog.Logger.Info($"[{TestContext.CurrentContext.Test.Name}] start test");
        }

        [TearDown]
        public void EndLog()
        {
            TestLog.Logger.Info($"[{TestContext.CurrentContext.Test.Name}] end test");
        }
    }
}
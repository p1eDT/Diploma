using Allure.Commons;
using Bogus;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Core.Selenium
{
    [AllureNUnit]
    public class BaseTest
    {
        private AllureLifecycle allure;
        protected TestLog logger;
        Faker faker = new Faker();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            allure = AllureLifecycle.Instance;
            logger = new TestLog();
        }

        [SetUp]
        public void SetUp()
        {
            TestLog.Logger.Info($"[{TestContext.CurrentContext.Test.Name}] start test");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                    byte[] bytes = screenshot.AsByteArray;
                    allure.AddAttachment("Screenshot", "image/png", bytes);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }

            TestLog.Logger.Info($"[{TestContext.CurrentContext.Test.Name}] end test");

            Browser.Instance.CloseBrowser();

        }
    }
}
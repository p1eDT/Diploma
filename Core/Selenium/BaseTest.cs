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
        public void SetUp()
        {
            allure = AllureLifecycle.Instance;
            logger = new TestLog();
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
            Browser.Instance.CloseBrowser();
        }
    }
}
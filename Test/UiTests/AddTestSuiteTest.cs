using BussinesObject.UI.Pages;
using Core.Selenium;

namespace Test.UiTests
{
    public class AddTestSuiteTest : BaseTest
    {
        [Test]
        public void CreateTestSuiteTest()
        {
            string testSuiteName = "LongChainTest";
            new LoginPage()
                .OpenPage()
                .Login()
                .SelectProject()
                .OpenSuites()
                .OpenNewTestSuiteModal()
                .CreateTestSuite(testSuiteName);
        }
    }
}
using BussinesObject.UI.Pages;
using Core.Selenium;

namespace Test.UiTests
{
    public class AddTestSuiteTest : BaseTest
    {
        [Test]
        public void CreateTestSuiteTest()
        {
            new LoginPage().OpenPage().Login();
            new TestSuitesPage()
                .OpenPage()
                .OpenNewTestSuiteModal()
                .CreateTestSuite("TestSuiteTest3");
        }

        [Test]
        public void CreateTestSuiteTest2()
        {
            new LoginPage()
                .OpenPage()
                .Login()
                .SelectProject()
                .OpenSuites()
                .OpenNewTestSuiteModal()
                .CreateTestSuite("LongChainTest");
        }
    }
}
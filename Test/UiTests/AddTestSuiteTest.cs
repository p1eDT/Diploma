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
                .OpenPageTS()
                .OpenNewTestSuiteModal()
                .CreateTestSuite("TestSuiteTest");
        }
    }
}
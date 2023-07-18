using BussinesObject.UI.Pages;
using Core.Selenium;

namespace Test.UiTests
{
    public class AddTestCaseTests : BaseTest
    {
        [Test]
        public void CreateTestCaseBasicTest()
        {
            new LoginPage().OpenPage().Login();
            new TestSuitesPage()
                .OpenPage()
                .OpenTestSuite("TestSuiteTest3")
                .OpenNewTestCaseModal()
                .CreateTestCase("TestTestTest","10");
        }
    }
}
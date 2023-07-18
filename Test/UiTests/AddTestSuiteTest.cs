using Bogus;
using BussinesObject.UI.Pages;
using Core.Selenium;

namespace Test.UiTests
{
    public class AddTestSuiteTest : BaseTest
    {
        [Test]
        public void CreateTestSuiteTest()
        {
            Faker faker = new Faker();
            string testSuiteName = faker.Commerce.ProductName();

            new LoginPage()
                .OpenPage()
                .Login()
                .SelectProject()
                .OpenSuites()
                .OpenNewTestSuiteModal()
                .CreateTestSuite(testSuiteName);

            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test suite {testSuiteName} created"));
        }
    }
}
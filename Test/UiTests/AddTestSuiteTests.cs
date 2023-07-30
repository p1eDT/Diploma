using Bogus;
using BusinessObject.UI.Pages;
using BusinessObject.UI.Steps;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class AddTestSuiteTests : BaseTest
    {

        [SetUp]
        public void Prepare()
        {
            new LoginPage()
                .Login()
                .SelectProject()
                .OpenSuites();
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        public void CreateTestSuiteTest()
        {
            var testSuite = TestSuitBuilder.CreateRandomTestSuitModel();
            var testSuitPage = new TestSuitesPage();

            testSuitPage
                .OpenNewTestSuiteModal()
                .CreateTestSuite(testSuite.Name, testSuite.Description);

            var alert = testSuitPage.GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test suite {testSuite.Name} created"));
        }
    }
}
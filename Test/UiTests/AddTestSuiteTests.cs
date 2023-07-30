using Bogus;
using BusinessObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class AddTestSuiteTests : BaseTest
    {

        [SetUp]
        public void Prepare()
        {
            new LoginPage().Login().SelectProject().OpenSuites();
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        public void CreateTestSuiteTest()
        {
            Faker faker = new Faker();
            string testSuiteName = faker.Commerce.ProductName();
            string description = faker.Commerce.ProductDescription();

            new TestSuitesPage().OpenNewTestSuiteModal().CreateTestSuite(testSuiteName, description);

            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test suite {testSuiteName} created"));
        }
    }
}
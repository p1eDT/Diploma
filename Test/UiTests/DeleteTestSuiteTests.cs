using Api.TestCase.Steps;
using Bogus.DataSets;
using BusinessObject.Api.Steps;
using BusinessObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Elements;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class DeleteTestSuiteTests : BaseTest
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        public void DeleteTSTest()
        {
            var projectId = 1;
            var testSuite = new ApiTestSuitSteps().CreateTestSuite(projectId);

            var testSuiteForDelete = testSuite.Name;
            logger.Message($"Test suite for delete: {testSuiteForDelete}");

            var suites = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject()
                        .OpenSuites()
                        .DeleteTestSuite(testSuiteForDelete);

            Assert.Throws<NoSuchElementException>(() => suites.TestSuiteByName(testSuiteForDelete));
        }
    }
}

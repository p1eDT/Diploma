using Bogus.DataSets;
using BusinessObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Elements;
using NUnit.Allure.Attributes;
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
            var testSuiteForDelete = "ForDelete";
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

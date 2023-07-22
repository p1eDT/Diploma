using Bogus.DataSets;
using BussinesObject.UI.Pages;
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
            var testSuiteForDelete = "proba";

            var suites = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject("Test1Project")
                        .OpenSuites()
                        .DeleteTestSuite(testSuiteForDelete);

            Assert.Throws<NoSuchElementException>(() => suites.TestSuiteByName(testSuiteForDelete));
        }
    }
}

using Bogus.DataSets;
using BussinesObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class DeleteTestSuiteTests : BaseTest
    {
        [Test]
        public void Test()
        {
            var testSuiteForDelete = "dsf";

            var suites = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject("Test1Project")
                        .OpenSuites()
                        .DeleteTestSuite(testSuiteForDelete);

            Thread.Sleep(3000);

            //Assert.That(suites.TestSuiteByName(testSuiteForDelete).Text, Is.EqualTo("dsf"));

            Assert.Throws<NoSuchElementException>(() => suites.TestSuiteByName(testSuiteForDelete));
        }
    }
}

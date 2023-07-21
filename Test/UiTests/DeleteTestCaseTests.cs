using BussinesObject.UI.Pages;
using Core.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UiTests
{
    public class DeleteTestCaseTests:BaseTest
    {
        [Test]
        public void DeleteTCTest()
        {
            var testCaseForDelete = "dsf";

            var cases = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject("Test1Project")
                        .OpenSuites()
                        .OpenTestSuite("proba")
                        .DeleteTestCase("123")
                        .DeleteTestCase("TC22");

            Thread.Sleep(3000);

            Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCaseForDelete));
        }
    }
}

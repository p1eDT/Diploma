using BussinesObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;
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
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        public void DeleteTCTest()
        {
            var testCaseForDelete = "dsf";

            var cases = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject("Test1Project")
                        .OpenSuites()
                        .OpenTestSuite("proba")
                        .DeleteTestCase("proba")
                        .DeleteTestCase("TC29");

            Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCaseForDelete));
        }
    }
}

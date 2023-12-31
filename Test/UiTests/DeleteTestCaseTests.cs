﻿using Api.TestCase.Steps;
using BusinessObject.Api.Services;
using BusinessObject.Api.Steps;
using BusinessObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class DeleteTestCaseTests : BaseTest
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        public void DeleteTCWithCreatedTestCasesTest()
        {
            var testSuitId = 42;
            var testSuite = new ApiTestSuitSteps().GetTestSuiteById(testSuitId).Name;
            
            var testCase = new ApiTestCaseSteps().CreateTestCase(testSuitId);
            logger.Message($"Test case for delete: {testCase.Name}");


            var cases = new LoginPage()
                        .OpenPage()
                        .Login()
                        .SelectProject()
                        .OpenSuites()
                        .OpenTestSuite(testSuite);

            cases.DeleteTestCase(testCase.Code);

            Assert.Throws<NoSuchElementException>(() => cases.GetTestNameByCode(testCase.Code));
            Assert.Throws<NoSuchElementException>(() => cases.GetTestCaseCode(testCase.Name));
        }
    }
}

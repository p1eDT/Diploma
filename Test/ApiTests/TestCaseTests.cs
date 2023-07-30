using Api.TestCase.Steps;
using Api.Tests;
using BusinessObject.Api.Services;
using BusinessObject.Api.Utils;
using Core.Selenium;
using NUnit.Allure.Attributes;
using System.Net;

namespace Test.ApiTests
{
    internal class TestCaseTests:ApiAuthTests
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]
        public void CreateTestCaseWithRandomName()
        {
            int testSuiteId = 42;
            var testCaseResponse = apiTestCaseSteps.CreateTestCase(testSuiteId);
            logger.Message($"Test case created with code: {testCaseResponse.Code} and name: {testCaseResponse.Name}");

            var test = testCaseService.GetTestCaseById(testCaseResponse.Id);
            Assert.That(test.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]
        public void UpdateTestCase()
        {
            int testSuiteId = 42;
            logger.Message($"--Prepare: creation test case");

            var oldtestCase = apiTestCaseSteps.CreateTestCase(testSuiteId);
            logger.Message($"--Prepare: test case created with " +
                $"\n code: {oldtestCase.Code} " +
                $"\n name: {oldtestCase.Name} " +
                $"\n id {oldtestCase.Id}");

            var newTestCaseValues = TestCaseModelBuilder.TestCaseModelRandomValue();
            var updateResultTestCase = apiTestCaseSteps.UpdateTestCase(newTestCaseValues, oldtestCase.Id);

            Assert.That(oldtestCase, Is.Not.EqualTo(updateResultTestCase));
        }
    }
}

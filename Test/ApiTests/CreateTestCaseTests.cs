using Api.Tests;
using BussinesObject.Api.Services;
using Core.Selenium;
using NUnit.Allure.Attributes;
using System.Net;

namespace Test.ApiTests
{
    internal class CreateTestCaseTests:ApiAuthTests
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
    }
}

using Api.Tests;
using BussinesObject.Api.Services;
using Core.Selenium;
using System.Net;

namespace Test.ApiTests
{
    internal class CreateTestCaseTests:ApiAuthTests
    {
        [Test]
        public void CreateTestCaseWithRandomName()
        {
            var TestCaseResponse = apiTestCaseSteps.CreateTestCase(1);
            logger.Message($"Test case code: {TestCaseResponse.Code}");

            var test = testCaseService.GetTestCaseById(TestCaseResponse.Id);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(test.StatusCode));
        }
    }
}

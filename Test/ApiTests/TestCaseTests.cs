using BusinessObject.Api.Utils;
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
            var oldTestCase = apiTestCaseSteps.CreateTestCase(testSuiteId);            

            var newTestCaseValues = TestCaseModelBuilder.TestCaseModelRandomValue();
            var updateResultTestCase = apiTestCaseSteps.UpdateTestCase(newTestCaseValues, oldTestCase.Id);

            Assert.That(oldTestCase, Is.Not.EqualTo(updateResultTestCase));
        }
    }
}
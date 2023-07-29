using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.TestCase;
using BussinesObject.Api.Services;
using BussinesObject.Api.Steps;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Net;

namespace Api.TestCase.Steps
{
    public class ApiTestCaseSteps : TestCaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="testSuiteId">test Suite Id in which will be created test case</param>
        /// <param name="name">TestCase name, if default create random with faker.Internet.DomainName</param>
        /// <returns></returns>
        public TestCaseModel CreateTestCase(int testSuiteId,string name=null)
        {
            logger.Info("Creating new test case in test suite {testsuit}", new ApiTestSuitSteps().GetTestSuiteById(testSuiteId));
            var testCaseModel = new CreateTestCaseModel()
            {
                TestSuiteId = testSuiteId,
                Name = name??faker.Internet.DomainName()
            };
            logger.Debug("testCaseModel: {@testCaseModel}", testCaseModel);

            var response = base.CreateTestCase(testCaseModel);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created));
            Assert.IsNotNull(response.Content);
            logger.Info($"Test case created");

            return JsonConvert.DeserializeObject<CommonResultResponse<TestCaseModel>>(response.Content).Data;
        }

        public new void DeleteTestCaseById(int id)
        {
            logger.Info($"Delete test case with id: {id}");
            var response = base.DeleteTestCaseById(id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent));
            Assert.IsEmpty(response.Content);

            logger.Info($"Test case id {id} was removed");
        }

        public new TestCaseModel UpdateTestCase(TestCaseModel testCaseModel, int testCaseId)
        {
            logger.Debug("Which testCaseModel to update: {@testCaseModel}", testCaseModel);
            var response = base.UpdateTestCase(testCaseModel, testCaseId);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);
            logger.Info("TestCase with id {testCaseId} was updated successfully", testCaseId);

            var responseModel = JsonConvert.DeserializeObject<CommonResultResponse<TestCaseModel>>(response.Content).Data;
            logger.Info("Updated test case values {@responseModel}", responseModel);

            return responseModel;
        }
    }
}
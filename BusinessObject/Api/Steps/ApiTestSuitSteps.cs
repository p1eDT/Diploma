using Api.BusinessObject.Steps;
using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.TestCase;
using BusinessObject.Api.RestEntities.TestSuite;
using BusinessObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Net;

namespace BusinessObject.Api.Steps
{
    public class ApiTestSuitSteps:TestSuiteService
    {
        [AllureStep("GetTestSuiteById {0}")]
        public new TestSuiteModel GetTestSuiteById(int id)
        { 
            var response = base.GetTestSuiteById(id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<TestSuiteModel>>(response.Content).Data;
        }

        [AllureStep("CreateTestSuite {0} {1}")]
        public TestSuiteModel CreateTestSuite(int projectId, string name = null)
        {
            logger.Info("Creating new test suite in project {projectId}", new ApiProjectSteps().GetProjectById(projectId));
            var TestSuiteModel = new CreateTestSuiteModel()
            {
                ProjectId = projectId,
                Name = name ?? faker.Internet.DomainName()
            };
            logger.Debug("TestSuiteModel: {@TestSuiteModel}", TestSuiteModel);

            var response = base.CreateTestSuite(TestSuiteModel);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created));
            Assert.IsNotNull(response.Content);
            logger.Info($"Test suite created");

            return JsonConvert.DeserializeObject<CommonResultResponse<TestSuiteModel>>(response.Content).Data;
        }
    }
}

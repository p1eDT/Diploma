using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.TestSuite;
using BusinessObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace BusinessObject.Api.Steps
{
    public class ApiTestSuitSteps:TestSuiteService
    { 
        public new TestSuiteModel GetTestSuiteById(int id)
        { 
            var response = base.GetTestSuiteById(id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<TestSuiteModel>>(response.Content).Data;
        }
    }
}

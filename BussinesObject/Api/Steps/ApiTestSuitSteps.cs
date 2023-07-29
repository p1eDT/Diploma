using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.TestSuite;
using BussinesObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace BussinesObject.Api.Steps
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

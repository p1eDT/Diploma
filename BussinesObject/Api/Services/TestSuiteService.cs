using Api.RestCore;
using BussinesObject.Api.RestEntities;
using Core.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace BussinesObject.Api.Services
{
    public class TestSuiteService : BaseService
    {
        public string TestSuitesEndpoint = "test-suites";
        public string TestSuiteById = "test-suites/{testSuiteId}";
        public TestSuiteService() : base(AppConfiguration.Api.BaseUrl)
        {
        }

        public RestResponse GetTestSuites()
        {
            var request = new RestRequest(TestSuitesEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetTestSuiteById(int id)
        {
            logger.Info("Get test Suite by id {id}", id);

            var request = new RestRequest(TestSuiteById).AddUrlSegment("testSuiteId", id);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateTestSuite(CreateTestSuiteModel testSuite)
        {
            logger.Debug(this.GetType().Name + " TestSuite: {@TestSuite}", testSuite);

            var body = JsonConvert.SerializeObject(testSuite);
            var request = new RestRequest(TestSuitesEndpoint, Method.Post);
            request.AddBody(body);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestSuiteById(int id)
        {
            var request = new RestRequest(TestSuiteById, Method.Delete).AddUrlSegment("testSuiteId", id);
            return apiClient.Execute(request);
        }

        public TestSuiteModel GetTestSuiteById<TestSuiteType>(string code) where TestSuiteType : TestSuiteModel
        {
            var request = new RestRequest(TestSuiteById).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<TestSuiteModel>>(request).Data;
        }

        public RestResponse UpdateTestSuite(CreateTestSuiteModel testSuite, int id)
        {
            var body = JsonConvert.SerializeObject(testSuite);
            var request = new RestRequest(TestSuiteById, Method.Put).AddUrlSegment("testSuiteId", id);
            request.AddBody(body);
            return apiClient.Execute(request);
        }
    }
}

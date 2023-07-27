using Api.RestCore;
using BussinesObject.Api.RestEntities;
using RestSharp;
using Core.Configuration;
using Newtonsoft.Json;

namespace BussinesObject.Api.Services
{
    public class TestCaseService:BaseService
    {
        public string TestCaseEndpoint = "test-cases";
        public string TestCaseById = "test-cases/{testCaseId}";
        public TestCaseService() : base(AppConfiguration.Api.BaseUrl)
        {
        }

        public RestResponse GetTestCases()
        {
            var request = new RestRequest(TestCaseEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetTestCaseById(int id)
        {
            var request = new RestRequest(TestCaseById).AddUrlSegment("testCaseId", id);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateTestCase(CreateTestCaseModel TestCase)
        {
            logger.Info(this.GetType().Name + " TestCase:" + System.Text.Json.JsonSerializer.Serialize(TestCase));

            var body = JsonConvert.SerializeObject(TestCase);
            var request = new RestRequest(TestCaseEndpoint, Method.Post);
            request.AddBody(body);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestCaseById(int id)
        {
            var request = new RestRequest(TestCaseById, Method.Delete).AddUrlSegment("testCaseId", id);
            return apiClient.Execute(request);
        }

        public TestCaseModel GetTestCaseByCode<TestCaseType>(string code) where TestCaseType : TestCaseModel
        {
            var request = new RestRequest(TestCaseById).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<TestCaseModel>>(request).Data;
        }
    }
}

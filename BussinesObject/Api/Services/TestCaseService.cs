using Api.RestCore;
using BussinesObject.Api.RestEntities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.Services
{
    internal class TestCaseService:BaseService
    {
        public string TestCaseEndpoint = "test-cases";
        public string TestCaseById = "test-cases/{testCaseId}";
        public TestCaseService(string url) : base(url)
        {
        }

        public RestResponse GetTestCases()
        {
            var request = new RestRequest(TestCaseEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetTestCaseByCode(string code)
        {
            var request = new RestRequest(TestCaseById).AddUrlSegment("testCaseId", code);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateTestCase(CreateTestCaseModel TestCase)
        {
            var request = new RestRequest(TestCaseEndpoint, Method.Post);
            request.AddBody(TestCase);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestCaseByCode(string code)
        {
            var request = new RestRequest(TestCaseById, Method.Delete).AddUrlSegment("testCaseId", code);
            return apiClient.Execute(request);
        }

        public TestCase GetTestCaseByCode<TestCaseType>(string code) where TestCaseType : TestCase
        {
            var request = new RestRequest(TestCaseById).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<TestCase>>(request).Result;
        }
    }
}

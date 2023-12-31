﻿using Api.RestCore;
using BusinessObject.Api.RestEntities;
using RestSharp;
using Core.Configuration;
using Newtonsoft.Json;
using BusinessObject.Api.RestEntities.TestCase;

namespace BusinessObject.Api.Services
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
            logger.Info("Get test case by id {id}",id);

            var request = new RestRequest(TestCaseById).AddUrlSegment("testCaseId", id);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateTestCase(CreateTestCaseModel testCase)
        {
            logger.Debug(this.GetType().Name + " TestCase: {@TestCase}", testCase);

            var body = JsonConvert.SerializeObject(testCase);
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

        public RestResponse UpdateTestCase(TestCaseModel testCase, int id)
        {
            var body = JsonConvert.SerializeObject(testCase);
            var request = new RestRequest(TestCaseById, Method.Put).AddUrlSegment("testCaseId", id);
            request.AddBody(body);
            return apiClient.Execute(request);
        }
    }
}

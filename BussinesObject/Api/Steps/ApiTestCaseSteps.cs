﻿using Bogus;
using BussinesObject.Api.RestEntities;
using BussinesObject.Api.Services;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace Api.TestCase.Steps
{
    public class ApiTestCaseSteps : TestCaseService
    {
        public new TestCaseModel CreateTestCase(int testSuiteId,string name=null)
        {
            var testCaseModel = new CreateTestCaseModel()
            {
                TestSuiteId = testSuiteId,
                Name = name??faker.Internet.DomainName()
            };
            logger.Debug("testCaseModel: {@testCaseModel}", testCaseModel);

            var response = base.CreateTestCase(testCaseModel);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<TestCaseModel>>(response.Content).Data;
        }
    }
}
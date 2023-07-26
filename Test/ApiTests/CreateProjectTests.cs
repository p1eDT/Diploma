﻿using Bogus;
using BussinesObject.Api.RestEntities;
using BussinesObject.Api.Services;
using System.Net;
using NUnit.Framework;
using NUnit.Allure.Attributes;

namespace Test.ApiTests
{
    public class CreateProjectTests:ApiAuthTests
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]
        public void CreateProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = "Test",
                Code = $"{new Faker().Finance.RoutingNumber()}",
                Access = "none"
            };

            var projectResponse = projectService.CreateProject(projectModel);
            ProjectHandler.AddProjectCodeForDelete(projectModel.Code);

            Console.WriteLine(projectResponse.Content);
            Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]
        public void GetProjects()
        {
            logger.Message("");
            var response = projectService.GetProjects();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}

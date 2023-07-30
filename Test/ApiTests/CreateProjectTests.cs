using Bogus;
using BusinessObject.Api.RestEntities;
using System.Net;
using NUnit.Framework;
using NUnit.Allure.Attributes;
using BusinessObject.Api.Utils;

namespace Test.ApiTests
{
    public class CreateProjectTests:ApiAuthTests
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]
        public void GetProjects()
        {
            var response = projectService.GetProjects();
            logger.Message($"Status code response: {response.StatusCode}");
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}

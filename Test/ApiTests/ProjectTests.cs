using System.Net;
using NUnit.Allure.Attributes;

namespace Test.ApiTests
{
    public class ProjectTests:ApiAuthTests
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
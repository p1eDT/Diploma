using Bogus;
using BussinesObject.Api.RestEntities;
using BussinesObject.Api.Services;
using System.Net;
using NUnit.Framework;

namespace Test.ApiTests
{
    public class CreateProjectTests:ApiAuthTests
    {
        [Test]

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
        public void GetProjects()
        {
            var response = projectService.GetProjects();
            Console.WriteLine(response.StatusCode);
            
        }
    }
}

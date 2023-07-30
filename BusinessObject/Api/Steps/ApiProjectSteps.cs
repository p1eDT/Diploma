using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.Project;
using BusinessObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Net;

namespace Api.BusinessObject.Steps
{
    public class ApiProjectSteps : ProjectService
    {
        [AllureStep("Get project by id: {0}")]
        public new ProjectModel GetProjectById(int id)
        {
            logger.Info(typeof(ProjectModel));
            var response = base.GetProjectById(id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<ProjectModel>>(response.Content).Data;
        }
    }
}
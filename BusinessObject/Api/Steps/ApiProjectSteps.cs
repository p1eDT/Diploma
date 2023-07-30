using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.Project;
using BusinessObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace Api.BusinessObject.Steps
{
    public class ApiProjectSteps : ProjectService
    {
        public new ProjectModel GetProjectByCode(string code)
        {
            var response = base.GetProjectByCode(code);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<ProjectModel>>(response.Content).Data;
        }
    }
}
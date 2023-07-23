using Api.RestCore;
using BussinesObject.Api.RestEntities;
using Core.Configuration;
using RestSharp;

namespace BussinesObject.Api.Services
{
    public class ProjectService : BaseService
    {
        public string ProjectEndpoint = "/projects";
        public string ProjectByCodeEndpoint = "/projects/{code}";

        public ProjectService() : base(AppConfiguration.Api.BaseUrl) { }

        public RestResponse GetProjects()
        {
            var request = new RestRequest(ProjectEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetProjectByCode(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint).AddUrlSegment("code", code);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteProjectByCode(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint, Method.Delete).AddUrlSegment("code", code);
            return apiClient.Execute(request);
        }

        public Project GetProjectByCode<ProjectType>(string code) where ProjectType : Project
        {
            var request = new RestRequest(ProjectByCodeEndpoint).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<Project>>(request).Result;
        }
    }
}

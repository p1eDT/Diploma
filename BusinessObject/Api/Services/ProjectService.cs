using Api.RestCore;
using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.Project;
using BusinessObject.Api.RestEntities.Project.Project;
using Core.Configuration;
using RestSharp;

namespace BusinessObject.Api.Services
{
    public class ProjectService : BaseService
    {
        public string ProjectEndpoint = "/projects";
        public string ProjectByIdEndpoint = "/projects/{id}";

        public ProjectService() : base(AppConfiguration.Api.BaseUrl) { }

        public RestResponse GetProjects()
        {
            var request = new RestRequest(ProjectEndpoint);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetProjectById(int id)
        {
            var request = new RestRequest(ProjectByIdEndpoint).AddUrlSegment("id", id);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteProjectById(int id)
        {
            var request = new RestRequest(ProjectByIdEndpoint, Method.Delete).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }

        public ProjectModel GetProjectById<ProjectType>(int id) where ProjectType : ProjectModel
        {
            var request = new RestRequest(ProjectByIdEndpoint).AddUrlSegment("id", id);
            return apiClient.Execute<CommonResultResponse<ProjectModel>>(request).Data;
        }
    }
}

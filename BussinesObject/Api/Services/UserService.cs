using Api.RestCore;
using BussinesObject.Api.RestEntities;
using Core.Configuration;
using RestSharp;

namespace BussinesObject.Api.Services
{
    public class UserService : BaseService
    {
        public string UserEndpoint = "/users";
        public string UserByIdEndpoint = "/users/{userId}";

        public UserService() : base(AppConfiguration.Api.BaseUrl) { }

        public RestResponse GetUsers()
        {
            var request = new RestRequest(UserEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetUserById(string userId)
        {
            var request = new RestRequest(UserByIdEndpoint).AddUrlSegment("userId", userId);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateUser(CreateUserModel user)
        {
            var request = new RestRequest(UserEndpoint, Method.Post);
            request.AddBody(user);
            return apiClient.Execute(request);
        }
    }
}

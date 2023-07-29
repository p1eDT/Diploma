using Api.RestCore;
using BussinesObject.Api.RestEntities;
using BussinesObject.Api.RestEntities.User;
using BussinesObject.Api.RestEntities.User.User;
using Core.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace BussinesObject.Api.Services
{
    public class UserService : BaseService
    {
        public string UserEndpoint = "/users";
        public string UserByIdEndpoint = "/users/{userId}";
        public string GrantAdmin = "/user/{userId}/make-admin";
        public string RevokeAdmin = "/user/{userId}/remove-admin";

        public UserService() : base(AppConfiguration.Api.BaseUrl) { }

        public RestResponse GetUsers()
        {
            var request = new RestRequest(UserEndpoint);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GetUserById(int userId)
        {
            var request = new RestRequest(UserByIdEndpoint).AddUrlSegment("userId", userId);

            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse CreateUser(CreateUserModel user)
        {
            logger.Info(this.GetType().Name+" User:" +System.Text.Json.JsonSerializer.Serialize(user));
            var body=JsonConvert.SerializeObject(user);
            var request = new RestRequest(UserEndpoint, Method.Post);
            request.AddBody(body);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteUser(int userId)
        {
            var request = new RestRequest(UserByIdEndpoint, Method.Delete).AddUrlSegment("userId", userId);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse GrantAdminPrivileges(int userId)
        {
            logger.Info("Grant admin privileges for " + JsonConvert.DeserializeObject<CommonResultResponse<UserModel>>(GetUserById(userId).Content).Data.Name);
            var request = new RestRequest(GrantAdmin, Method.Post).AddUrlSegment("userId", userId);
            var response = apiClient.Execute(request);
            return response;
        }

        public RestResponse RevokeAdminPrivileges(int userId)
        {
            logger.Info("Remove admin privileges for " + JsonConvert.DeserializeObject<CommonResultResponse<UserModel>>(GetUserById(userId).Content).Data.Name);
            var request = new RestRequest(RevokeAdmin, Method.Post).AddUrlSegment("userId", userId);
            var response = apiClient.Execute(request);
            return response;
        }
    }
}
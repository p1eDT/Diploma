﻿using Api.RestCore;
using BussinesObject.Api.RestEntities;
using Core.Configuration;
using Newtonsoft.Json;
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
    }
}
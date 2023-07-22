using Core.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Api.RestCore
{
    public class BaseApiClient
    {
        private RestClient restClient;

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false,
                Authenticator= AddToken()
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public JwtAuthenticator AddToken()
        {
            return new JwtAuthenticator(AppConfiguration.Api.Token);
        }

        public RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = restClient.Execute<T>(request);
            return response.Data;
        }
    }
}
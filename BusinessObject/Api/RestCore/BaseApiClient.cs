using BusinessObject.Api.RestEntities;
using Core.Configuration;
using Newtonsoft.Json;
using NLog;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;
using System.Reflection;

namespace Api.RestCore
{
    public class BaseApiClient
    {
        private RestClient restClient;

        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false,
                Authenticator = AddToken()
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public JwtAuthenticator AddToken(string? token = null)
        {
            token ??= AddBasicToken();
            return new JwtAuthenticator(token);
        }

        public string AddBasicToken()
        {
            return AppConfiguration.Api.Token;
        }

        public virtual RestResponse Execute(RestRequest request)
        {
            RestResponse response = null;

            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();
                response = restClient.Execute(request);
                stopWatch.Stop();

                return response;
            }
            catch (Exception e)
            {
                logger.Error($"Failed to execute {e}");
            }
            finally
            {
                LogRequest(request, response, stopWatch.ElapsedMilliseconds);
            }

            return null;
        }

        public virtual T Execute<T>(RestRequest request) where T : new()
        {
            RestResponse response = null;
            var stopWatch = new Stopwatch();

            try
            {
                stopWatch.Start();
                response = restClient.Execute(request);
                stopWatch.Stop();

                var returnType = JsonConvert.DeserializeObject<T>(response.Content);
                return returnType;
            }
            catch (Exception e)
            {
                logger.Error($"Failed to execute {e}");
            }
            finally
            {
                LogRequest(request, response, stopWatch.ElapsedMilliseconds);
            }

            return default(T);
        }

        private void LogRequest(RestRequest request, RestResponse response, long durationMs)
        {
            logger.Debug(() =>
            {
                var requestToLog = new
                {
                    parameters = request.Parameters.Select(parameter => new
                    {
                        name = parameter.Name,
                        value = parameter.Value,
                        type = parameter.Type.ToString()
                    }),
                };

                return String.Format("Request parameters: {0}", requestToLog);
            }); 

            logger.Info(() =>
            {
                var requestToLog = new
                {
                    resource = request.Resource,
                    method = request.Method.ToString(),
                    uri = restClient.BuildUri(request),
                };

                var responseToLog = new
                {
                    statusCode = response.StatusCode,
                    content = response.Content,
                    //headers = response.Headers,
                    responseUri = response.ResponseUri,
                    errorMessage = response.ErrorMessage,
                };

                return string.Format("Request completed in {0} ms\n" +
                    "Request: {1}\n" +
                    "Response: {2}",
                    durationMs, System.Text.Json.JsonSerializer.Serialize(requestToLog),
                    JsonConvert.SerializeObject(responseToLog));
            });

        }
    }
}
using Api.RestCore;
using Core.Configuration;

namespace Api.Tests
{
    public class BaseApiTest
    {
        protected BaseApiClient apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            apiClient = new BaseApiClient(AppConfiguration.Api.BaseUrl);
        }
    }
}
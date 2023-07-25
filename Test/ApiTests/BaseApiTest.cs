using Allure.Commons;
using Api.RestCore;
using Core.Configuration;
using NUnit.Allure.Core;

namespace Api.Tests
{
    [AllureNUnit]
    public class BaseApiTest
    {
        protected BaseApiClient apiClient;
        private AllureLifecycle allure;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            apiClient = new BaseApiClient(AppConfiguration.Api.BaseUrl);
            allure = AllureLifecycle.Instance;
        }
    }
}
using Allure.Commons;
using Api.RestCore;
using Core.Configuration;
using NUnit.Allure.Core;

namespace Api.Tests
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
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
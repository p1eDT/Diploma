using Api.BusinessObject.Steps;
using Api.Tests;
using BussinesObject.Api.Services;
using Core.Configuration;

namespace Test.ApiTests
{
    public class ApiAuthTests : BaseApiTest
    {
        protected ProjectService projectService;
        protected ApiProjectSteps apiProjectSteps;

        [OneTimeSetUp]
        public void SetUp()
        {
            projectService = new ProjectService();
            apiProjectSteps = new ApiProjectSteps();
        }

        //[OneTimeSetUp]
        //public void InitialService()
        //{
        //    apiClient.AddToken(AppConfiguration.Api.Token);
        //}
    }
}

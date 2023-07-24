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
        protected UserService userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            projectService = new ProjectService();
            apiProjectSteps = new ApiProjectSteps();
            userService = new UserService();
        }

        //[OneTimeSetUp]
        //public void InitialService()
        //{
        //    apiClient.AddToken(AppConfiguration.Api.Token);
        //}
    }
}

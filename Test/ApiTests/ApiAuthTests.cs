﻿using Api.BusinessObject.Steps;
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
        protected ApiUserSteps apiUserSteps;

        [OneTimeSetUp]
        public void SetUp()
        {
            projectService = new ProjectService();
            apiProjectSteps = new ApiProjectSteps();
            userService = new UserService();
            apiUserSteps = new ApiUserSteps();
        }
    }
}

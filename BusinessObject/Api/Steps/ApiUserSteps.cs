using Bogus;
using BusinessObject.Api.RestEntities;
using BusinessObject.Api.RestEntities.User;
using BusinessObject.Api.RestEntities.User.User;
using BusinessObject.Api.Services;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Net;

namespace Api.BusinessObject.Steps
{
    public class ApiUserSteps : UserService
    {
        public ApiUserSteps() : base()
        {
        }

        [AllureStep]
        public UserModel CreateRandomUser()
        {
            var password = faker.Internet.Password(prefix:"4#");

            var userModel = new CreateUserModel()
            {
                FirstName = $"{faker.Person.FirstName}",
                LastName = $"{faker.Person.LastName}",
                Email = $"{faker.Person.Email}",
                Password = password,
                PasswordConfirmation = password,
                Admin = false
            };

            logger.Debug("Generate random user model {@userModel}", userModel);
            var userResponse = base.CreateUser(userModel);

            Assert.IsTrue(userResponse.StatusCode.Equals(HttpStatusCode.Created));
            logger.Info("Created random user {@userModel}", userModel);

            return JsonConvert.DeserializeObject<CommonResultResponse<UserModel>>(userResponse.Content).Data;
        }
    }
}
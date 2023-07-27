using Api.BusinessObject.Steps;
using Bogus;
using BussinesObject.Api.RestEntities;
using NUnit.Allure.Attributes;
using System.Net;

namespace Test.ApiTests
{
    public class UserTests : ApiAuthTests
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void CreateUser()
        {
            Faker faker = new Faker();

            var userModel = new CreateUserModel()
            {
                FirstName = $"{faker.Person.FirstName}",
                LastName = $"{faker.Person.LastName}",
                Email = $"{faker.Person.Email}",
                Password = "P@ssw0rd!",
                PasswordConfirmation = "P@ssw0rd!",
                Admin = false
            };

            var userResponse = userService.CreateUser(userModel);

            Console.WriteLine(userResponse.Content);
            Assert.IsTrue(userResponse.StatusCode.Equals(HttpStatusCode.Created));
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void GetSingleUser()
        {
            int userId = 1;

            var response = userService.GetUserById(userId);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void DeleteUser()
        {
            User userForDelete = apiUserSteps.CreateRandomUser();

            var response = userService.DeleteUser(userForDelete.Id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent));
        }
    }
}
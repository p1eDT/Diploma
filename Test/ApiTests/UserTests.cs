using Bogus;
using BussinesObject.Api.RestEntities.User;
using BussinesObject.Api.RestEntities.User.User;
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

        public void CreateUserTest()
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

        public void GetSingleUserTest()
        {
            int userId = 1;

            var response = userService.GetUserById(userId);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);
        }

        [Test]
        [Category("Smoke")]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void DeleteUserTest()
        {
            UserModel userForDelete = apiUserSteps.CreateRandomUser();

            var response = userService.DeleteUser(userForDelete.Id);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent));
        }

        [Test]
        [AllureTag("Negative tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void GetDeletedUserTest()
        {
            int userId = 2;

            var response = userService.DeleteUser(userId);

            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NotFound));
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("API")]

        public void AdminPrivilegesTest()
        {
            int userId = 8;

            var grant = userService.GrantAdminPrivileges(userId);
            Assert.IsTrue(grant.StatusCode.Equals(HttpStatusCode.OK));

            var revoke = userService.RevokeAdminPrivileges(userId);
            Assert.IsTrue(revoke.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}
using Bogus;
using BussinesObject.Api.RestEntities;
using System.Net;

namespace Test.ApiTests
{
    public class CreateUserTests : ApiAuthTests
    {
        [Test]
                
        public void CreateUser()
        {
            Faker faker = new Faker();

            var userModel = new CreateUserModel()
            {
                FirstName = $"{faker.Person.FirstName}",
                LastName = $"{faker.Person.LastName}",
                Email = "kavphqvaf@exelica.com",
                Password = "P@ssw0rd!",
                PasswordConfirmation = "P@ssw0rd!"
            };

            var userResponse = userService.CreateUser(userModel);

            Console.WriteLine(userResponse.Content);
            //Assert.IsTrue(userResponse.StatusCode.Equals(HttpStatusCode.OK));

        }

        //[Test]
        //public void GetProjects()
        //{
        //    var response = projectService.GetProjects();
        //    Console.WriteLine(response.StatusCode);
        //    Console.WriteLine(response.Content.ToString());
        //}
    }
}

using Bogus;
using BussinesObject.Api.RestEntities;
using BussinesObject.Api.Services;
using Newtonsoft.Json;

namespace Api.BusinessObject.Steps
{
    public class ApiUserSteps : UserService
    {
        public ApiUserSteps() : base()
        {
        }

        public User CreateRandomUser() 
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

            var userResponse = base.CreateUser(userModel);

            return JsonConvert.DeserializeObject<UserResponse>(userResponse.Content).data;
        }
    }
}
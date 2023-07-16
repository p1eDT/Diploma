using Bogus;
using Core;
using Core.Configuration;

namespace BussinesObject
{
    public class UserBuilder
    {
        public static UserModel GetUserFromAppSettings()
        {
            return new UserModel
            (
                name: AppConfiguration.Browser.ListOfUsers[0].Name,
                password: AppConfiguration.Browser.ListOfUsers[0].Password
            );
        }

        public static UserModel GetFakerUser()
        {
            Faker faker = new Faker();
            return new UserModel
            (
                name: faker.Internet.Email(),
                password: faker.Internet.Password()
             );
        }
    }
}

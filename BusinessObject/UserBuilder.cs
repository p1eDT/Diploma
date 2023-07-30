using Bogus;
using Core;
using Core.Configuration;

namespace BusinessObject
{
    public class UserBuilder
    {
        public static UserModel GetUserFromAppSettings()
        {
            return new UserModel
            (
                email: AppConfiguration.Browser.ListOfUsers[0].Email,
                password: AppConfiguration.Browser.ListOfUsers[0].Password
            );
        }

        public static UserModel GetFakerUser()
        {
            Faker faker = new Faker();
            return new UserModel
            (
                email: faker.Internet.Email(),
                password: faker.Internet.Password()
             );
        }

        public static UserModel EmptyUser()
        {
            return new UserModel
            (
                email: "",
                password: ""
             );
        }
    }
}

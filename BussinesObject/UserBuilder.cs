using Core;
using Core.Configuration;

namespace BussinesObject
{
    public class UserBuilder
    {
        public static UserModel GetUserFromAppSettings()
        {
            return new UserModel(
                name: AppConfiguration.Browser.ListOfUsers[0].Name,
                password: AppConfiguration.Browser.ListOfUsers[0].Password
                );
        }
    }
}

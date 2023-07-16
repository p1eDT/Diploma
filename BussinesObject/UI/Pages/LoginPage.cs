using Core;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class LoginPage : BasePage
    {
        Input EmailInput = new("email");
        Input PasswordInput = new("password");
        Button LoginButton = new("primary is-fullwidth");
        By ErrorMessage = By.ClassName("message-body");
        public string TextMessage = "These credentials do not match our records.";

        public LoginPage()
        {
        }

        public MyProjectsPage Login()
        {
            TryToLogin(UserBuilder.GetUserFromAppSettings());
            return new MyProjectsPage();
        }

        public void TryToLogin(UserModel userModel)
        {
            EmailInput.GetElement().SendKeys(userModel.Name);
            PasswordInput.GetElement().SendKeys(userModel.Password);
            LoginButton.GetElement().Click();
        }

        public override LoginPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(BaseUrl);
            return this;
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(ErrorMessage).Text;
        }

        public LoginPage LoginAsFakeUser()
        {
            TryToLogin(UserBuilder.GetFakerUser());
            return this;
        }
    }
}

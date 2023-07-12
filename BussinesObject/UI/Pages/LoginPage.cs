using Core;
using Core.Configuration;
using Core.Selenium;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class LoginPage : BasePage
    {
        public string url = AppConfiguration.Browser.Site;

        private By EmailInput = By.Id("email");
        private By PasswordInput = By.Id("password");
        private By LoginButton = By.XPath("//button[@type='submit']");

        public LoginPage() 
        {
        }

        public LoginPage Login() 
        {
            TryToLogin(UserBuilder.GetUserFromAppSettings());
            return this;
        }

        public void TryToLogin(UserModel userModel)
        {
            Driver.FindElement(EmailInput).SendKeys(userModel.Name);
            Driver.FindElement(PasswordInput).SendKeys(userModel.Password);
            Driver.FindElement(LoginButton).Click();
        }

        public override LoginPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}

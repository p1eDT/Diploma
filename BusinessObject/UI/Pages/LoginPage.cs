﻿using Core;
using Core.Selenium;
using Core.Selenium.Elements;
using NLog;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
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
            OpenPage();
        }

        public MyProjectsPage Login()
        {
            TryToLogin(UserBuilder.GetUserFromAppSettings());
            return new MyProjectsPage();
        }

        public void TryToLogin(UserModel userModel)
        {
            Logger.Info("Try to login by {@value}", userModel);

            EmailInput.GetElement().SendKeys(userModel.Email);
            PasswordInput.GetElement().SendKeys(userModel.Password);
            LoginButton.GetElement().Click();
        }

        public override LoginPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(BaseUrl);
            Logger.Info("Opened Login Page");
            return this;
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(ErrorMessage).Text;
        }

        public string GetPopupMessage()
        {
            return PasswordInput.GetElement().GetAttribute("validationMessage");
        }

        public LoginPage LoginAsFakeUser()
        {
            TryToLogin(UserBuilder.GetFakerUser());
            return this;
        }
    }
}

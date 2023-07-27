using BussinesObject;
using BussinesObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        public void LoginUser()
        {
            var homePage = new LoginPage()
                .Login();

            Assert.That(homePage.BrandUrl(), Is.EqualTo(BasePage.BaseUrl));
        }

        //[AllureTag("Negative tests")]
        //[AllureOwner("NotNikita")]
        //[AllureSuite("TestMonitor")]
        //[Test]
        //public void LoginAsFakeUser()
        //{
        //    var message = new LoginPage()
        //        .LoginAsFakeUser();

        //    Assert.That(message.GetErrorMessage(), Is.EqualTo(message.TextMessage));
        //}

        //[AllureTag("Negative tests")]
        //[AllureOwner("NotNikita")]
        //[AllureSuite("TestMonitor")]
        //[Test]
        //public void LoginWithEmptyUser()
        //{
        //    var user = UserBuilder.EmptyUser();
        //    var loginPage = new LoginPage();
        //    loginPage.TryToLogin(user);

        //    Assert.That(loginPage.GetPopupMessage(), Is.EqualTo("Заполните это поле."));
        //}
    }
}

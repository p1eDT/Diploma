using BusinessObject;
using BusinessObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("UI")]
        public void LoginUser()
        {
            var homePage = new LoginPage()
                .Login();

            Assert.That(homePage.BrandUrl(), Is.EqualTo(BasePage.BaseUrl));
        }

        [Test]
        [AllureTag("Negative tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("UI")]
        public void LoginAsFakeUser()
        {
            var message = new LoginPage()
                .LoginAsFakeUser();

            Assert.That(message.GetErrorMessage(), Is.EqualTo(message.TextMessage));
        }

        [Test]
        [AllureTag("Negative tests")]
        [AllureOwner("NotNikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("UI")]
        public void LoginWithEmptyUser()
        {
            var user = UserBuilder.EmptyUser();
            var loginPage = new LoginPage();
            loginPage.TryToLogin(user);

            Assert.That(loginPage.GetPopupMessage(), Is.EqualTo("Заполните это поле."));
        }
    }
}
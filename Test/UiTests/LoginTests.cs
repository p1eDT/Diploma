using BussinesObject.UI.Pages;
using Core.Selenium;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginUser()
        {
            var homePage = new LoginPage().OpenPage().Login();

            var brandLogoUrl = homePage.Header.Brand.FindElement(By.TagName("a")).GetAttribute("href");

            Assert.That(brandLogoUrl, Is.EqualTo(BasePage.BaseUrl));
        }

        [Test]
        public void LoginAsFakeUser()
        {
            var message = new LoginPage().OpenPage().LoginAsFakeUser();

            Assert.That(message.TextMessage, Is.EqualTo(message.GetErrorMessage()));
        }
    }
}

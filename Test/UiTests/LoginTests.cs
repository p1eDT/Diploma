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
            var login = new LoginPage().OpenPage().Login();

            //TODO put this in a separate class or step
            var brandLogoUrl = Browser.Instance.Driver.FindElement(By.CssSelector(".navbar-brand")).FindElement(By.TagName("a")).GetAttribute("href");

            Assert.That(brandLogoUrl, Is.EqualTo(login.url));
        }
    }
}

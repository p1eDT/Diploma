using Core.Selenium;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class HeaderNavigation:BasePage
    {
        private By brand = By.CssSelector(".navbar-brand>a");
        private By settings = By.XPath("//div[@class='navbar-end']/a");
        private By account = By.CssSelector("a.navbar-link:has(figure)");
        private By navMenu = By.CssSelector("div.navbar-start");

        public IWebElement Brand;
        public IWebElement Settings;
        public IWebElement Account;
        public IWebElement NavMenu;

        public HeaderNavigation()
        {
            Brand = Browser.Instance.Driver.FindElement(brand);
            Settings = Browser.Instance.Driver.FindElement(settings);
            Account = Browser.Instance.Driver.FindElement(account);
            NavMenu = Browser.Instance.Driver.FindElement(navMenu);
        }

        public override HeaderNavigation OpenPage()
        {
            throw new NotImplementedException();
        }

        public void ClickNavMenuItem(string item) 
        {
            Logger.Info($"Try click in navigation menu to {item}");
            NavMenu.FindElement(By.LinkText(item)).Click();
        }
    }
}

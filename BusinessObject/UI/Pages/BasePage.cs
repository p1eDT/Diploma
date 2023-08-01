using Core.Configuration;
using Core.Selenium;
using NLog;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected Logger Logger;

        public static string BaseUrl=AppConfiguration.Browser.Site;

        public BasePage()
        {
            Driver = Browser.Instance.Driver;
            Logger = Browser.Logger;
        }

        public abstract BasePage OpenPage();
    }
}

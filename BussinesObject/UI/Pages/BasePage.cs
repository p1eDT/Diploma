using Core.Selenium;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        public BasePage()
        {
            Driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();
    }
}

using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public class HomePage : BasePage
    {
        private By alertLocator= By.XPath("//div[@role='alert']");

        protected string homeUrl = $"{BaseUrl}my - projects";
        public string Alert;

        public HeaderNavigation Header = new HeaderNavigation();

        public HomePage():base()
        {
        }

        public override HomePage OpenPage() 
        {
            Browser.Instance.NavigateToUrl(homeUrl);
            return this;
        }

        public string GetAlertText() 
        {
            return Driver.FindElement(alertLocator).Text;
            
        }

        public string BrandUrl()
        {
            return Header.Brand.GetAttribute("href");
        }

        public void SearchElement(string name)
        {
            Input search = new("search");
            search.SetText(name);
        }
    }
}

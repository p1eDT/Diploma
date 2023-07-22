using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class HomePage : BasePage
    {
        protected string homeUrl = $"{BaseUrl}my - projects";
        public string Alert;

        public HeaderNavigation Header = new HeaderNavigation();

        public HomePage()
        {
        }

        public override HomePage OpenPage() 
        {
            Browser.Instance.NavigateToUrl(homeUrl);
            return this;
        }

        public string GetAlertText() 
        {
            Alert = Driver.FindElement(By.XPath("//div[@role='alert']")).Text;
            return Alert; 
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

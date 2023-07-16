using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class BaseElement
    {
        protected IWebDriver WebDriver => Browser.Instance.Driver;
        public IWebElement GetElement() => WebDriver.FindElement(locator);
        protected By locator;

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public BaseElement(string xpath)
        {
            locator = By.XPath(xpath);
        }

        public object ClickElementViaJs()
        {
            return Browser.Instance.ExecuteScript("arguments[0].click();", GetElement());
        }
        //public string GetElementAttribute(string xpath, string attribute) 
        //{
        //    locator = By.XPath(xpath);
            
        //    return value;
        //}
    }
}

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
            Browser.Logger.Debug("Element by locator: {@locator}", locator);
        }

        public BaseElement(string xpath)
        {
            locator = By.XPath(xpath);
            Browser.Logger.Debug("Element xpath: {xpath}", locator);
        }

        public object ClickElementViaJs()
        {
            return Browser.Instance.ExecuteScript("arguments[0].click();", GetElement());
        }
    }
}

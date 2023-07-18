using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class LinkText : BaseElement
    {
        public LinkText(By locator) : base(locator)
        {
        }

        public LinkText(string className, string text) : base($"//*[@class='{className}'][contains(text(),'{text}')]")
        {

        }
    }
}
using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class LinkTest : BaseElement
    {
        public LinkTest(By locator) : base(locator)
        {
        }

        public LinkTest(string className, string text) : base($"//*[@class='{className}'][contains(text(),'{text}')]")
        {

        }
    }
}

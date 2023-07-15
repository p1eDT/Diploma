using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string name) : base($"//label[contains(text(),{name})]/following-sibling::div/input")
        
        {
        }
    }
}

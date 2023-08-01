using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string type, string name) : base($"//input[@type='{type}'][@name='{name}']")
        {
        }

        public Input(string type) : base($"//input[@type='{type}']")
        {
        }

        public void SetText(string text)
        {
            GetElement().Clear();
            GetElement().SendKeys(text);
        }
    }
}
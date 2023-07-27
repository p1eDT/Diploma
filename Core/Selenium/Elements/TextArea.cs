using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class TextArea : BaseElement
    {
        public TextArea(By locator) : base(locator)
        {
        }

        public TextArea(string name) : base($"//textarea[@name='{name}']")
        {
        }

        public void SetText(string text)
        {
            GetElement().Clear();
            GetElement().SendKeys(text);
        }
    }
}
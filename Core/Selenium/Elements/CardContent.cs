using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class CardContent : BaseElement
    {
        public CardContent(By locator) : base(locator)
        {
        }

        public CardContent(string value) : base($"//button[@class='button is-{value}']")
        {
        }
    }
}

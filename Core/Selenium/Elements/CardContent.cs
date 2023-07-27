using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class CardContent : BaseElement
    {
        public CardContent() : base(By.XPath("//*[@class='card-content']"))
        { 
        }
    }
}

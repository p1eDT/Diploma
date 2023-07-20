using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class TestCasesPage : BasePage
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";
        Button AddTestCaseButton = ButtonBuilder.AddButton();

        public TestCasesPage()
        {
        }

        public override TestCasesPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);

            return this;
        }

        public NewTestCaseModal OpenNewTestCaseModal()
        {
            AddTestCaseButton.ClickElementViaJs();

            return new NewTestCaseModal();
        }

        public string GetTestCaseCode(string name)
        {
            return Driver.FindElement(By.XPath($"//div[contains(text(),'{name}')]//ancestor::tr//td[@data-label='Code']//strong")).Text;
        }
    }
}
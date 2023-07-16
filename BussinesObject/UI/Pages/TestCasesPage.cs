using Core.Selenium;
using Core.Selenium.Elements;

namespace BussinesObject.UI.Pages
{
    public class TestCasesPage : BasePage
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";
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
            new Button("primary").ClickElementViaJs();

            return new NewTestCaseModal();
        }
    }
}
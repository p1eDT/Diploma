using Core.Selenium;
using Core.Selenium.Elements;

namespace BussinesObject.UI.Pages
{
    public class TestSuitesPage : HomePage
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";

        public TestSuitesPage()
        {
        }

        public override TestSuitesPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public NewTestSuiteModal OpenNewTestSuiteModal()
        {
            new Button("primary").ClickElementViaJs();

            return new NewTestSuiteModal();
        }

        public TestCasesPage OpenTestSuite(string nameTestSuite)
        {
            new LinkText("is-link is-inverted", nameTestSuite).ClickElementViaJs();
            return new TestCasesPage();
        }
    }
}
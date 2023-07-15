using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class TestSuitesPage : BasePage
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";

        //наверное надо создать какую-то BaseTemplatePage:BasePage и от нее наследоваться, чтобы хедер везде не добавлять
        HeaderNavigation Header = new HeaderNavigation();

        public TestSuitesPage()
        {
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public TestSuitesPage OpenPageTS()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public NewTestSuiteModal OpenNewTestSuiteModal()
        {
            new Button("primary").GetElement().Click();

            return new NewTestSuiteModal();
        }
    }
}
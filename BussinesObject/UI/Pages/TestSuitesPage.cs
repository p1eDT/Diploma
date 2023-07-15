using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

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
        //по идее теперь не нужно
        //public TestSuitesPage OpenPageTS()
        //{
        //    Browser.Instance.NavigateToUrl(url);
        //    return this;
        //}

        public NewTestSuiteModal OpenNewTestSuiteModal()
        {
            new Button("primary").GetElement().Click();

            return new NewTestSuiteModal();
        }
    }
}
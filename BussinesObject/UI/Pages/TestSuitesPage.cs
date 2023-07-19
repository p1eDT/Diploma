using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class TestSuitesPage : HomePage, IDelete
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";
        Button AddTestSuiteButton = ButtonBuilder.AddButton();

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
            AddTestSuiteButton.ClickElementViaJs();
            return new NewTestSuiteModal();
        }

        public TestCasesPage OpenTestSuite(string nameTestSuite)
        {
            new LinkText("is-link is-inverted", nameTestSuite).ClickElementViaJs();
            return new TestCasesPage();
        }

        public TestSuitesPage DeleteTestSuite(string testSuiteName) 
        {
            var testSuitesDeletable = this as IDelete;
            testSuitesDeletable.Delete(testSuiteName);
            return new TestSuitesPage(); 
        }

        public string TestSuiteByName(string name)
        {
            return Driver.FindElement(By.LinkText(name)).Text;
        }
    }
}
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class TestSuitesPage : HomePage, IDelete
    {
        Button AddTestSuiteButton = ButtonBuilder.AddButton();

        public TestSuitesPage()
        {
        }

        public override TestSuitesPage OpenPage()
        {
            new MyProjectsPage().OpenPage().SelectProject().OpenSuites();

            return this;
        }

        public NewTestSuiteModal OpenNewTestSuiteModal()
        {
            AddTestSuiteButton.ClickElementViaJs();

            return new NewTestSuiteModal();
        }

        public TestCasesPage OpenTestSuite(string nameTestSuite)
        {
            Logger.Info("Try to open by {@value} test suite", nameTestSuite);
            base.SearchElement(nameTestSuite);
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
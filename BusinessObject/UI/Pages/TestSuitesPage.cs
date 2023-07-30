using Core.Selenium.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public class TestSuitesPage : HomePage, IDelete
    {
        Button AddTestSuiteButton = ButtonBuilder.AddButton();

        public TestSuitesPage()
        {
        }

        public override TestSuitesPage OpenPage()
        {
            new MyProjectsPage()
                .OpenPage()
                .SelectProject()
                .OpenSuites();
            Logger.Info("Opened test suites page");
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
            Logger.Info("Try find test suite by name");
            var testSuite = Driver.FindElement(By.LinkText(name)).Text;
            if (!String.IsNullOrEmpty(testSuite))
            {
                Logger.Info($"Found test suite {testSuite}");
            }
            else
            {
                Logger.Info($"Test suite not found");
                Assert.Fail();
            }
            return testSuite;
        }
    }
}
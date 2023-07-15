using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class NewTestSuiteModal
    {
        Input testSuiteName = new("Name");
        Button addButton = new("success");

        public void CreateTestSuite(string name)
        {
            testSuiteName.GetElement().SendKeys(name);
            addButton.GetElement().Click();
        }
    }
}

using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class NewTestSuiteModal
    {
        Input testSuiteName = new("Name");
        Button addButton = new("success");

        public void CreateAccount(string name)
        {
            testSuiteName.GetElement().SendKeys(name);
            addButton.GetElement().Click();
        }
    }
}

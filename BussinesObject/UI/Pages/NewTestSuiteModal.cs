using Core.Selenium.Elements;

namespace BussinesObject.UI.Pages
{
    public class NewTestSuiteModal
    {
        Input testSuiteName = new("text","name");
        Button addButton = new("success");

        public void CreateTestSuite(string name)
        {
            testSuiteName.GetElement().SendKeys(name);
            addButton.ClickElementViaJs();
        }
    }
}

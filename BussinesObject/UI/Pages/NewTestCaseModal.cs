using Core.Selenium.Elements;

namespace BussinesObject.UI.Pages
{
    public class NewTestCaseModal
    {
        Input testCaseName = new("text", "name");
        Input duration = new("tel", "duration");
        Button addButton = new("success");

        public void CreateTestCase(string name,string time)
        {
            testCaseName.GetElement().SendKeys(name);
            duration.GetElement().SendKeys(time);
            addButton.ClickElementViaJs();
        }
    }
}
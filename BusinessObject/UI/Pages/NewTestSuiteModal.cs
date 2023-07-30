using Core.Selenium.Elements;

namespace BusinessObject.UI.Pages
{
    public class NewTestSuiteModal
    {
        Input TestSuiteName = new("text","name");
        TextArea Description = new("description");

        public void CreateTestSuite(string name, string description)
        {
            TestSuiteName.SetText(name);
            Description.SetText(description);
            ButtonBuilder.SuccessButton().ClickElementViaJs();
        }
    }
}

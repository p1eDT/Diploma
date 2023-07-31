using BusinessObject.UI.Pages.Modals;
using Core.Selenium;
using Core.Selenium.Elements;

namespace BusinessObject.UI.Pages
{
    public class NewTestSuiteModal:AddModal
    {
        Input TestSuiteName = new("text","name");
        TextArea Description = new("description");

        public void CreateTestSuite(string name, string description)
        {
            TestSuiteName.SetText(name);
            Description.SetText(description);
            SuccessButton.ClickElementViaJs();

            WaitHelper.WaitHideElement(Driver, modalForm);
        }
    }
}

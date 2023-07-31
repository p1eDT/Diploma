using Bogus;
using BusinessObject.UI.Pages.Modals;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public class NewTestCaseModal:AddModal
    {
        By stepTextDiv = By.XPath("//p[@data-placeholder]/parent::div[contains(@class,'is-input')]");
        By durationDangerP = By.XPath("//p[@class='help is-danger']");
        Button plusButton = new(By.XPath("//a[@class='button is-primary']"));

        Input testCaseName = new("text", "name");
        Input duration = new("tel", "duration");
        Input stepInput = new(By.XPath("//div[@class='ProseMirror is-input']"));

        Faker faker = new Faker();

        public void CreateTestCase(string name,string time)
        {
            testCaseName.SetText(name);
            duration.SetText(time);
            SuccessButton.ClickElementViaJs();

            if (!Driver.FindElement(durationDangerP).Displayed)
            {
                Logger.Info("No errors found, pending hide");
                WaitHelper.WaitHideElement(Driver, modalForm);
            }
            else
            {
                Logger.Info("Validation errors found: {DangerText}", GetDangerText());
            }
        }

        public void CreateTestCase(string name, string time, int stepCount)
        {
            testCaseName.SetText(name);
            duration.GetElement().SendKeys(time);

            stepInput.GetElement().SendKeys(faker.Name.JobDescriptor());

            for (int i = 1; i < stepCount; i++)
            {
                plusButton.ClickElementViaJs();

                var input = Driver.FindElement(stepTextDiv);
                input.SendKeys(faker.Name.JobDescriptor());
            }

            SuccessButton.ClickElementViaJs();
        }

        public string GetDangerText()
        {
            return Driver.FindElement(durationDangerP).Text;
        }
    }
}
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public class TestCasesPage : HomePage,IDelete
    {
        private string url = $"{BaseUrl}web-ap/design/test-suites";
        Button AddTestCaseButton = ButtonBuilder.AddButton();

        public TestCasesPage()
        {
        }

        public override TestCasesPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);

            return this;
        }

        public NewTestCaseModal OpenNewTestCaseModal()
        {
            AddTestCaseButton.ClickElementViaJs();

            return new NewTestCaseModal();
        }

        public TestCasesPage DeleteTestCase(string testCase)
        {
            var testCaseNameDeletable = this as IDelete;
            testCaseNameDeletable.Delete(testCase);

            return this;
        }

        public string GetTestCaseCode(string name)
        {
            //todo так можем получать любой элемент в таблице из любого 
            // кроме чекбокса и заголовка (th). Пустой type вернет правый контрол с доп действиями
            //*[contains(text(),'{name}')]/ancestor::tr//td[@data-label='type']
            return Driver.FindElement(By.XPath($"//div[contains(text(),'{name}')]//ancestor::tr//td[@data-label='Code']//strong")).Text;
        }

        public string GetTestNameByCode(string code)
        {
            //todo так можем получать любой элемент в таблице из любого 
            // кроме чекбокса и заголовка (th). Пустой type вернет правый контрол с доп действиями
            //*[contains(text(),'{name}')]/ancestor::tr//td[@data-label='type']
            return Driver.FindElement(By.XPath($"//div[contains(text(),'{code}')]//ancestor::tr//td[@data-label='Name']//strong")).Text;
        }
    }
}
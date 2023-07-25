using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
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

        /// <summary>
        /// Delete TestCase
        /// </summary>
        /// <param name="testCase">Name or Code</param>
        /// <returns></returns>
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
    }
}
using Bogus.DataSets;
using BussinesObject.UI.Pages;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace Test.UiTests
{
    public class DeleteTestSuiteTests:BaseTest
    {
        [Test]
        public void Test()
        {
            new LoginPage()
                .OpenPage()
                .Login()
                .SelectProject("Test1Project")
                .OpenSuites();

            var checkBox = CheckBoxBuilder.GetCheckBoxInTableByName("test3");

            checkBox.SetCheckBoxState(true);

            //удаление через dropdawn элемент, который появляется после выбора какого-нибудь элемента
            //рядом с кнопкой фильтра вверху таблицы
            Button selectedButton = new(By.XPath("//button[@type='button' and @class='button']"));
            By deleteButton = By.XPath("//div[contains(text(),'Delete')]");
            selectedButton.ClickElementViaJs();
            Browser.Instance.Driver.FindElement(deleteButton).Click();

            //модалка с подтвеждением удаления
            CheckBox shureCheckBox = new(By.XPath("//section[@class='modal-card-body']/descendant::input"));
            shureCheckBox.SetCheckBoxState(true);
            Button deleteButtonSure = new("danger");
            deleteButtonSure.ClickElementViaJs();

            //Check delete testSuite;
            //Assert.IsNull(selectedButton);
            

        }
    }
}

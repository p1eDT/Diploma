using OpenQA.Selenium;


namespace Core.Selenium.Elements
{
    public class CheckBoxBuilder
    {
        public static CheckBox GetCheckBoxInTableByName(string name)
        {
            return new CheckBox(By.XPath($"//*[contains(text(),'{name}')]/ancestor::tr//input[@type='checkbox']"));         
        }

        public static CheckBox GetCheckBoxInTableByCode(string code)
        {
            return GetCheckBoxInTableByName(code);
        }

        public static CheckBox GetCheckBoxConfirmation()
        {
            return new CheckBox(By.XPath("//section[@class='modal-card-body']/descendant::input"));
        }
    }
}

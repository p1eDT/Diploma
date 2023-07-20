using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class ButtonBuilder
    {
        public static Button SelectedDropdownButton()
        {
            return new Button(By.XPath("//button[@type='button' and @class='button']"));
        }

        public static Button ConfirmationDeleteButton()
        {
            return new Button("danger");
        }

        public static Button ConfirmationCancelButton()
        {
            return new Button("white");
        }

        public static Button DeleteInDropDownButton()
        {
            return new Button(By.XPath("//div[contains(text(),'Delete')]"));
        }

        public static Button AddButton() 
        { 
            return new Button("primary");
        }

        public static Button SuccessButton()
        {
            return new Button("success");
        }
    }
}

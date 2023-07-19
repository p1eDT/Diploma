using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

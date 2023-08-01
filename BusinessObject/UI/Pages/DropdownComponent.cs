using Core.Selenium.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.UI.Pages
{
    public class DropdownComponent
    {
        public static Button SelectedDropdownButton = new Button(By.XPath("//button[@type='button' and @class='button']"));
        public static Button DeleteInDropDownButton = new Button(By.XPath("//div[contains(text(),'Delete...')]"));
    }
}

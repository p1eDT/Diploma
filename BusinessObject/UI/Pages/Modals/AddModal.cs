using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.UI.Pages.Modals
{
    public class AddModal:BaseModal
    {
        public By modalForm=By.CssSelector("div.modal-card");
        public static Button SuccessButton= new Button("success");
    }
}

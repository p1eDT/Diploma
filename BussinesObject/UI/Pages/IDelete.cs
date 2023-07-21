using Core.Selenium.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.UI.Pages
{
    public interface IDelete
    {
        public void Delete(string item)
        {
            CheckItem(item);
            DeleteFromDropdown();
            IsConfirm();
            Thread.Sleep(1000);
        }

        public void CheckItem(string item)
        {
            CheckBoxBuilder.GetCheckBoxInTableByName(item).SetCheckBoxState(true);
        }

        public void DeleteFromDropdown()
        {
            ButtonBuilder.SelectedDropdownButton().ClickElementViaJs();
            ButtonBuilder.DeleteInDropDownButton().ClickElementViaJs();
        }

        public void IsConfirm(bool confirm=true)
        {
            if (confirm)
            {
                CheckBoxBuilder.GetCheckBoxConfirmation().SetCheckBoxState(true);
                ButtonBuilder.ConfirmationDeleteButton().ClickElementViaJs();
            }
            else
            { 
                ButtonBuilder.ConfirmationCancelButton().ClickElementViaJs();
            }
        }
    }
}

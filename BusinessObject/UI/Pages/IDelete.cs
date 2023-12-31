﻿using BusinessObject.UI.Pages.Modals;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public interface IDelete
    {
        static By modalConfirm = By.CssSelector("div.modal-card");

        public void Delete(string item)
        {
            Browser.Logger.Info("Try delete item {item}", item);

            CheckItem(item);
            DeleteFromDropdown();
            IsConfirm();

            Browser.Logger.Info("Item {item} has deleted", item);

            WaitHelper.WaitHideElement(Browser.Instance.Driver, modalConfirm);
        }

        public void CheckItem(string item)
        {
            CheckBoxBuilder.GetCheckBoxInTableByName(item).SetCheckBoxState(true);
        }

        public void DeleteFromDropdown()
        {
            DropdownComponent.SelectedDropdownButton.ClickElementViaJs();
            DropdownComponent.DeleteInDropDownButton.ClickElementViaJs();
        }

        public void IsConfirm(bool confirm=true)
        {
            if (confirm)
            {
                CheckBoxBuilder.GetCheckBoxConfirmation().SetCheckBoxState(true);
                ConfirmModal.ConfirmationDeleteButton.ClickElementViaJs();
            }
            else
            {
                ConfirmModal.ConfirmationCancelButton.ClickElementViaJs();
            }
        }
    }
}

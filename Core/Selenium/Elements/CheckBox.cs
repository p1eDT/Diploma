using NLog;
using OpenQA.Selenium;

namespace Core.Selenium.Elements
{
    public class CheckBox:Input
    {
        public CheckBox(By locator) : base(locator)
        {
        }

        public CheckBox(string type="checkbox") : base($"{type}")
        {
        }

        public void SetCheckBoxState(bool flag)
        {
            var element = this.GetElement();
            var selected = element.Selected;
            bool.TryParse(element.GetAttribute("checked"), out bool selectedByAttribute);

            if ((selected || selectedByAttribute) != flag)
            {
                this.GetElement().SendKeys(Keys.Space);
                Browser.Logger.Info("Element {@element} has been {checkState}", element.ToString(), (flag ? "checked": "unchecked"));
                Browser.Logger.Debug("Element {@element} has been {@checkState}", element, (flag ? "checked": "unchecked"));
            }
        }
    }
}

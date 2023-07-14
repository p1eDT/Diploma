using Core.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.UI.Pages
{
    public class HeaderNavigation:BasePage
    {
        //brand,settings,account одинаковые и есть на всех страницах насколько я увидел, можно сразу конструкторе прописать
        public IWebElement Brand;
        public IWebElement Settings;
        public IWebElement Account;

        //само меню везде есть, но его наполнение отличается
        public IWebElement NavMenu;

        public HeaderNavigation()
        {
            Brand =Browser.Instance.Driver.FindElement();
            Settings = Browser.Instance.Driver.FindElement();
            Account = Browser.Instance.Driver.FindElement();
            NavMenu = Browser.Instance.Driver.FindElement();
        }

        public override HeaderNavigation OpenPage()
        {
            throw new NotImplementedException();
        }
    }
}

using Core.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.UI.Pages
{
    public class HomePage : BasePage
    {
        protected string homeUrl = $"{BaseUrl}my - projects";

        public HeaderNavigation Header = new HeaderNavigation();

        public HomePage()
        {
        }

        public override HomePage OpenPage() 
        {
            Browser.Instance.NavigateToUrl(homeUrl);
            return this;
        }
    }
}

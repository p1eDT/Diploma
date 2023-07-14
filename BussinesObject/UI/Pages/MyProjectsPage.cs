using Core.Configuration;
using Core.Selenium;
using NUnit.Engine.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.UI.Pages
{
    public class MyProjectsPage : BasePage
    {
        private string url = $"{BaseUrl}my - projects";

        //наверное надо создать какую-то BaseTemplatePage:BasePage и от нее наследоваться, чтобы хедер везде не добавлять
        HeaderNavigation Header = new HeaderNavigation();

        public MyProjectsPage()
        {
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}

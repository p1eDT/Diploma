using Core.Selenium;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class MyProjectsPage : HomePage
    {
        public MyProjectsPage()
        {
        }

        public override MyProjectsPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(homeUrl);
            return this;
        }

        public ProjectPage SelectProject(string projectName= "Web Application Starter Kit")
        {
            Driver.FindElement(By.XPath($"//h3[text()='{projectName}']")).Click();
            return new ProjectPage();
        }
    }
}

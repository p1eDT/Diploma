﻿using Core.Selenium;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
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
            Logger.Info("Select project: {project}", projectName);
            Driver.FindElement(By.XPath($"//h3[text()='{projectName}']")).Click();
            return new ProjectPage();
        }
    }
}

﻿namespace BusinessObject.UI.Pages
{
    public class ProjectPage : HomePage
    {
        public ProjectPage()
        {
        }
        public TestSuitesPage OpenSuites()
        {
            Header.ClickNavMenuItem("Design");
            return new TestSuitesPage();
        }
    }
}
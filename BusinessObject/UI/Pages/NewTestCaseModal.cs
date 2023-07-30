﻿using Bogus;
using Core.Selenium;
using Core.Selenium.Elements;
using OpenQA.Selenium;

namespace BusinessObject.UI.Pages
{
    public class NewTestCaseModal
    {
        Input testCaseName = new("text", "name");
        Input duration = new("tel", "duration");
        Button addButton = ButtonBuilder.SuccessButton();
        Button plusButton = new(By.XPath("//a[@class='button is-primary']"));
        Faker faker = new Faker();

        public void CreateTestCase(string name,string time)
        {
            testCaseName.SetText(name);
            duration.SetText(time);
            addButton.ClickElementViaJs();
        }

        public void CreateTestCase(string name, string time, int stepCount)
        {
            testCaseName.SetText(name);
            duration.GetElement().SendKeys(time);

            var inputFirst = Browser.Instance.Driver.FindElement(By.XPath("//div[@class='ProseMirror is-input']"));
            inputFirst.SendKeys(faker.Name.JobDescriptor());

            for (int i = 1; i < stepCount; i++)
            {
                plusButton.ClickElementViaJs();

                var input = Browser.Instance.Driver.FindElement(By.XPath("//p[@data-placeholder]/parent::div[contains(@class,'is-input')]"));
                input.SendKeys(faker.Name.JobDescriptor());
            }

            addButton.ClickElementViaJs();
        }

        public string GetDangerText()
        {
            return Browser.Instance.Driver.FindElement(By.XPath("//p[@class='help is-danger']")).Text;
        }
    }
}
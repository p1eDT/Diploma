using Bogus;
using BussinesObject.UI.Pages;
using Core.Selenium;

namespace Test.UiTests
{
    public class AddTestCaseTests : BaseTest
    {
        [Test]
        public void CreateTestCaseBasicTest()
        {
            Faker faker = new Faker();
            string nameTestCase = faker.Lorem.Word();
            string duration = faker.Random.Number(100).ToString();
            string testSuite = "TestSuiteTest3";

            new LoginPage().OpenPage().Login();
            var testSuites = new TestSuitesPage().OpenPage();
            testSuites.SearchElement(testSuite);
            testSuites.OpenTestSuite(testSuite).OpenNewTestCaseModal().CreateTestCase(nameTestCase, duration);

            string testCaseCode = new TestCasesPage().GetTestCaseCode(nameTestCase);
            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));
        }

        [Test]
        public void CreateTestCaseFullTest()
        {
            Faker faker = new Faker();
            string nameTestCase = faker.Lorem.Word();
            string duration = faker.Random.Number(100).ToString();
            int stepCount = 4;
            string testSuite = "TestSuiteTest3";

            new LoginPage().OpenPage().Login();
            var testSuites = new TestSuitesPage().OpenPage();
            testSuites.SearchElement(testSuite);
            testSuites.OpenTestSuite(testSuite).OpenNewTestCaseModal().CreateTestCase(nameTestCase, duration, stepCount);

            //string testCaseCode = new TestCasesPage().GetTestCaseCode(nameTestCase);
            //string alert = new HomePage().GetAlertText();

            //Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));
        }
    }
}
using Bogus;
using BussinesObject.UI.Pages;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class AddTestCaseTests : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            new LoginPage().OpenPage().Login();
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        public void CreateTestCaseBasicTest()
        {
            Faker faker = new Faker();
            string nameTestCase = faker.Lorem.Word();
            string duration = faker.Random.Number(100).ToString();
            string testSuite = "TestSuiteTest3";

            
            var testSuites = new TestSuitesPage().OpenPage();
            testSuites.SearchElement(testSuite);
            testSuites.OpenTestSuite(testSuite).OpenNewTestCaseModal().CreateTestCase(nameTestCase, duration);

            string testCaseCode = new TestCasesPage().GetTestCaseCode(nameTestCase);
            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        public void CreateTestCaseFullTest()
        {
            Faker faker = new Faker();
            string nameTestCase = faker.Lorem.Word();
            string duration = faker.Random.Number(100).ToString();
            int stepCount = 2;
            string testSuite = "TestSuiteTest3";

            var testSuites = new TestSuitesPage().OpenPage();
            testSuites.SearchElement(testSuite);
            testSuites.OpenTestSuite(testSuite).OpenNewTestCaseModal().CreateTestCase(nameTestCase, duration, stepCount);

            string testCaseCode = new TestCasesPage().GetTestCaseCode(nameTestCase);
            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));
        }

        [Test]
        [AllureTag("Negative tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        public void DurationValidTest()
        {
            Faker faker = new Faker();
            string nameTestCase = faker.Lorem.Word();
            string duration = string.Empty;
            string testSuite = "TestSuiteTest3";

            var testSuites = new TestSuitesPage().OpenPage();
            testSuites.SearchElement(testSuite);
            var testCase = testSuites.OpenTestSuite(testSuite).OpenNewTestCaseModal();

            duration = "abc";
            testCase.CreateTestCase(nameTestCase, duration);

            Assert.That(testCase.GetDangerText(), Is.EqualTo("The duration must be an integer."));

            duration = "50000";
            testCase.CreateTestCase(nameTestCase, duration);

            Assert.That(testCase.GetDangerText(), Is.EqualTo("The duration must not be greater than 10000."));

            duration = "-12";
            testCase.CreateTestCase(nameTestCase, duration);

            Assert.That(testCase.GetDangerText(), Is.EqualTo("The duration must be at least 0."));
        }
    }
}
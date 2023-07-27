using BussinesObject.UI.Pages;
using BussinesObject.UI.Steps;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class AddTestCaseTests : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            new LoginPage().OpenPage().Login().SelectProject().OpenSuites();
        }

        [Test]
        [AllureTag("Positive tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("UI")]
        public void CreateTestCaseTest()
        {
            string testSuiteName = "TestSuiteTest3";
            var testCase = new TestCaseBuilder().GetRandomTestCaseModel(testSuiteName);

            new TestSuitesPage().OpenTestSuite(testCase.TestSuiteName)
                .OpenNewTestCaseModal()
                .CreateTestCase(testCase.NameTestCase, testCase.Duration, testCase.StepCount);

            string testCaseCode = new TestCasesPage().GetTestCaseCode(testCase.NameTestCase);
            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));
        }

        [Test]
        [AllureTag("Negative tests")]
        [AllureOwner("Nikita")]
        [AllureSuite("TestMonitor")]
        [AllureSubSuite("UI")]
        public void DurationValidTest()
        {
            string testSuiteName = "TestSuiteTest3";
            var testCase = new TestCaseBuilder().GetRandomTestCaseModel(testSuiteName);

            var testCaseModal = new TestSuitesPage().OpenTestSuite(testSuiteName).OpenNewTestCaseModal();

            testCase.Duration = "abc";
            testCaseModal.CreateTestCase(testCase.NameTestCase, testCase.Duration);
            Assert.That(testCaseModal.GetDangerText(), Is.EqualTo("The duration must be an integer."));

            testCase.Duration = "50000";
            testCaseModal.CreateTestCase(testCase.NameTestCase, testCase.Duration);
            Assert.That(testCaseModal.GetDangerText(), Is.EqualTo("The duration must not be greater than 10000."));

            testCase.Duration = "-12";
            testCaseModal.CreateTestCase(testCase.NameTestCase, testCase.Duration);
            Assert.That(testCaseModal.GetDangerText(), Is.EqualTo("The duration must be at least 0."));
        }
    }
}
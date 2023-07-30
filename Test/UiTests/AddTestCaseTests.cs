using Api.TestCase.Steps;
using BusinessObject.UI.Pages;
using BusinessObject.UI.Steps;
using Core.Selenium;
using NUnit.Allure.Attributes;

namespace Test.UiTests
{
    public class AddTestCaseTests : BaseTest
    {
        TestSuitesPage Suites;

        [SetUp]
        public void Prepare()
        {
            Suites = new LoginPage().Login().SelectProject().OpenSuites();
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
            
            Suites.OpenTestSuite(testCase.TestSuiteName)
                  .OpenNewTestCaseModal()
                  .CreateTestCase(testCase.NameTestCase, testCase.Duration, testCase.StepCount);

            string testCaseCode = new TestCasesPage().GetTestCaseCode(testCase.NameTestCase);
            string alert = new HomePage().GetAlertText();

            Assert.That(alert, Is.EqualTo($"Test case {testCaseCode} created"));

            int testCaseId=int.Parse(testCaseCode.Substring(2));
            new ApiTestCaseSteps().DeleteTestCaseById(testCaseId);
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

            var testCaseModal = Suites.OpenTestSuite(testSuiteName)
                                      .OpenNewTestCaseModal();

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
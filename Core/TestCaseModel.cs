namespace Core
{
    public class TestCaseModel
    {
        public string NameTestCase { get; set; }
        public string Duration { get; set; }
        public string TestSuiteName { get; set; }
        public int StepCount { get; set; }

        public TestCaseModel(string nameTestCase, string duration,string testSuiteName, int stepCount = 0)
        {
            NameTestCase = nameTestCase;
            Duration = duration;
            TestSuiteName = testSuiteName;
            StepCount = stepCount;
        }

        public override string? ToString()
        {
            return $"The {NameTestCase} test case from the {TestSuiteName} test suite contains {Duration} steps";
        }
    }
}
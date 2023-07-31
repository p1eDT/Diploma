using Bogus;
using Core;

namespace BusinessObject.UI.Steps
{
    public class TestCaseBuilder: BaseBuilder
    {
        private TestCaseModel RandomTestCaseModel(string testSuite)
        {
            return new TestCaseModel
            (
                nameTestCase: faker.Lorem.Word(),
                duration: faker.Random.Number(100).ToString(),
                testSuiteName: testSuite,
                stepCount: faker.Random.Number(10)
             );
        }

        public static TestCaseModel GetRandomTestCaseModel(string testSuite)=>new TestCaseBuilder().RandomTestCaseModel(testSuite);
    }
}
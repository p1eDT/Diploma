using Bogus;
using Core;

namespace BusinessObject.UI.Steps
{
    public class TestCaseBuilder
    {
        public TestCaseModel GetRandomTestCaseModel(string testSuite)
        {
            Faker faker = new Faker();

            return new TestCaseModel
            (
                nameTestCase: faker.Lorem.Word(),
                duration: faker.Random.Number(100).ToString(),
                testSuiteName: testSuite,
                stepCount: faker.Random.Number(10)
             );
        }
    }
}
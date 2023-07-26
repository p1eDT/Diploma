using Bogus;
using Core;

namespace BussinesObject.UI.Steps
{
    public class TestCaseBuilder
    {
        public TestCaseModel GetRandomTestCase(string testSuite)
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
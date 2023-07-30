using Bogus;
using BusinessObject.Api.RestEntities.TestSuite;
using Core.Selenium;

namespace BusinessObject.UI.Steps
{
    public class TestSuitBuilder
    {
        public static TestSuiteModel CreateRandomTestSuitModel(int projectId = 1)
        {
            Faker faker = new Faker();

            return new TestSuiteModel()
            {
                ProjectId = projectId,
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription()
            };
        }
    }
}

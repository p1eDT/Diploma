using Bogus;
using BusinessObject.Api.RestEntities.TestSuite;
using Core.Selenium;
using System.Runtime.CompilerServices;

namespace BusinessObject.UI.Steps
{
    public class TestSuitBuilder: BaseBuilder
    {
        private TestSuiteModel RandomTestSuitModel(int projectId)
        {
            return new TestSuiteModel()
            {
                ProjectId = projectId,
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription()
            };
        }

        public static TestSuiteModel CreateRandomTestSuitModel(int projectId = 1) =>new TestSuitBuilder().RandomTestSuitModel(projectId);

    }
}

using Bogus;
using BussinesObject.Api.RestEntities.TestCase;

namespace BussinesObject.Api.Utils
{
    public static class TestCaseModelBuilder
    {
        public static TestCaseModel TestCaseModelRandomValue()
        {
            Faker faker = new();
            return new TestCaseModel()
            {
                Id = faker.Random.UShort(2),
                Code = faker.Random.String(2),
                Name = faker.Name.JobTitle()
            };         
        }
    }
}

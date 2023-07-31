using Newtonsoft.Json;

namespace BusinessObject.Api.RestEntities.TestCase
{
    public class CreateTestCaseModel
    {
        [JsonProperty("test_suite_id", Required = Required.Always)]
        public int TestSuiteId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
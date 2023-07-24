using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities
{
    public class CreateTestCaseModel
    {
        [JsonProperty("test_suite_id")]
        public int TestSuiteId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool Draft { get; set; }

        [JsonProperty("expected_result")]
        public string ExpectedResult { get; set; }

        [JsonProperty("test_data")]
        public string TestData { get; set; }
        public string Preconditions { get; set; }
        public List<string> Instructions { get; set; }
    }
}
using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities
{
    public class TestCaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

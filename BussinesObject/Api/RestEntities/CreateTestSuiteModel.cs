using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.RestEntities
{
    public class CreateTestSuiteModel
    {
        [JsonProperty("project_id", Required = Required.Always)]
        public int ProjectId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

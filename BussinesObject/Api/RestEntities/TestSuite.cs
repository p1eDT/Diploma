using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObject.Api.RestEntities
{
    internal class TestSuite
    {
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("test_cases_count")]
        public int TestCasesCount { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("deleted_at")]
        public DateTime DeletedAt { get; set; }
    }
}

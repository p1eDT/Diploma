using Newtonsoft.Json;
using System.ComponentModel;

namespace BussinesObject.Api.RestEntities
{
    public class User
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public bool Admin { get; set; }
        public bool Owner { get; set; }

        [JsonProperty("last_login_at")]
        public DateTime LastLoginAt { get; set; }
        public bool TwoFactor { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }

        [JsonProperty("teams_count")]
        public int TeamsCount { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("memberships_count")]
        public int MembershipsCount { get; set; }
        public Endpoints Endpoints { get; set; }
        public Links Links { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime DeletedAt { get; set; }
    }
}

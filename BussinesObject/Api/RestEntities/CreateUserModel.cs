﻿using Newtonsoft.Json;

namespace BussinesObject.Api.RestEntities
{
    public class CreateUserModel
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("password_confirmation")]
        public string PasswordConfirmation { get; set; }

        public bool Admin { get; set; }
        public Array Teams { get; set; }
    }
}

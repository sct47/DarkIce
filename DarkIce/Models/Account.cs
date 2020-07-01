using System;
using Newtonsoft.Json;

namespace DarkIce
{
    public class Account
    {

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("accountBalance")]
        public string AccountBalance { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("eyeColor")]
        public string EyeColor { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("registered")]
        public string Registered { get; set; }

        public bool IsRecent
        {
            get
            {
                int year = int.Parse(Registered.Split(' ')[3]);
                return year > 2015;
            }
        }
    }
}

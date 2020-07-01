using System;
using Newtonsoft.Json;

namespace DarkIce
{
    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        public string FullName
        {
            get
            {
                return $"{First} {Last}";
            }
        }
    }
}

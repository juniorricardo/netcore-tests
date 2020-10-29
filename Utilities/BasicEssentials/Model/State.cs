#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasicEssentials.Model
{
    public class State
    {
        
        [JsonProperty("Map", NullValueHandling = NullValueHandling.Ignore)]
        public Map? Map { get; set; }

        [JsonProperty("Items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item>? Items { get; set; }

        [JsonProperty("Extension", NullValueHandling = NullValueHandling.Ignore)]
        public Extension? Extension { get; set; }

        public State()
        {
           
        }
        
    }
}
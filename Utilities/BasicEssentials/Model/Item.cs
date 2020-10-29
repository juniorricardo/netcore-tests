using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasicEssentials.Model
{
    public class Item
    {
        [JsonProperty("UUID", NullValueHandling = NullValueHandling.Ignore)]
        public string Uuid { get; set; }
        
        [JsonProperty("FriendlyName",NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; set; }
        
        [JsonProperty("props", NullValueHandling = NullValueHandling.Ignore)]
        public Props Props { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Frecuency { get; set; }

        public Item()
        {
        }
    }
}

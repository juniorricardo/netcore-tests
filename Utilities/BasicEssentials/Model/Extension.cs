using Newtonsoft.Json;

namespace BasicEssentials.Model
{
    public class Extension
    {
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Decorations { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CableType { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectivityStatus { get; set; }
        
    }
}
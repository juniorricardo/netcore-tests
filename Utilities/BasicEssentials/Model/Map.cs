using Newtonsoft.Json;

namespace BasicEssentials.Model
{
    public class Map
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        
        [JsonProperty("UUID", NullValueHandling = NullValueHandling.Ignore)]
        public string Uuid { get; set; }
        
        [JsonProperty("FriendlyName",NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; set; }
        
        [JsonProperty("Frequency",NullValueHandling = NullValueHandling.Ignore)]
        public string Frequency { get; set; }
        
        [JsonProperty("Icon",NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }
        
        [JsonProperty("Layer3Link", NullValueHandling = NullValueHandling.Ignore)]
        public string Layer3Link { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayInMap { get; set; }
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsHidden { get; set; }
        
    }
}
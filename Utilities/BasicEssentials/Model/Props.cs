using Newtonsoft.Json;

namespace BasicEssentials.Model
{
    public class Props
    {
        
        [JsonProperty("RGW", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rgw { get; set; }

        [JsonProperty("subscriberId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SubscriberId { get; set; }

        [JsonProperty("OUI", NullValueHandling = NullValueHandling.Ignore)]
        public string Oui { get; set; }

        [JsonProperty("Serial Number", NullValueHandling = NullValueHandling.Ignore)]
        public long? SerialNumber { get; set; }

        [JsonProperty("Product Class", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductClass { get; set; }

        [JsonProperty("IP Address", NullValueHandling = NullValueHandling.Ignore)]
        public string IpAddress { get; set; }

        [JsonProperty("Software Version", NullValueHandling = NullValueHandling.Ignore)]
        public string SoftwareVersion { get; set; }

        [JsonProperty("Online", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Online { get; set; }
        
        [JsonProperty("networkmap.hostname.label", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkmapHostnameLabel { get; set; }

        [JsonProperty("networkmap.ipaddress.label", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkmapIpaddressLabel { get; set; }

        [JsonProperty("networkmap.MACAddress.label", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkmapMacAddressLabel { get; set; }

        [JsonProperty("networkmap.manufacturer.label", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkmapManufacturerLabel { get; set; }

        [JsonProperty("networkmap.AddressSource.label", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkmapAddressSourceLabel { get; set; }
        
    }
}
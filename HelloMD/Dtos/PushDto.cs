using System.Text.Json.Serialization;

namespace HelloMD.Dtos
{
    public class PushDto
    {
        public struct aps
        {
            public struct alert
            {
                [JsonPropertyName("loc-key")]
                public string LocKey { get; set; }
                [JsonPropertyName("loc-args")]
                public string LocArgs { get; set; }
            }
            public string sound { get; set; }
            public string id { get; set; }
            public string request_id { get; set; }
            public string push_type { get; set; }
            public string payload { get; set; }
        }

        public struct pn_gcm
        {
            public struct data
            {
                public string message { get; set; }
            }
        }
    }
}

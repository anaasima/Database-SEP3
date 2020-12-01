using System;
using System.Text.Json.Serialization;

namespace Database_SEP3.Networking.Util
{
    public class NetworkPackage
    {
        [JsonPropertyName("type")]
        public string NetworkType { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }

    }
}
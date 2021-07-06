using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlockHistoryApp.Service.Common
{
    public class EtherumPayload
    {

        public static string projectId = "9d1b5930f82f479d89cf87310d59b51b";
        public static string baseUrl = $"https://mainnet.infura.io/v3/{projectId}";

        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("params")]
        public object[] Params { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

    }
}

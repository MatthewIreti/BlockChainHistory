using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlockHistoryApp.Repository.Database
{
    public class BlockEntity    
    {
        public int Id { get; set; }
        [JsonPropertyName("gasLimit")]
        public string GasLimit { get; set; }

        [JsonPropertyName("gasUsed")]
        public string GasUsed { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("miner")]
        public string Miner { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DockerBlockchainRest.Models
{
    public class ContractClass
    {
        public class Result
        {
            [JsonPropertyName("anonymous")]
            public bool Anonymous { get; set; }

            [JsonPropertyName("inputs")]
            public List<Input> Inputs { get; set; } = new List<Input>();

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("outputs")]
            public List<Output> Outputs { get; set; } = new List<Output>();

            [JsonPropertyName("stateMutability")]
            public string StateMutability { get; set; }
        }
        public class Input
        {
            [JsonPropertyName("indexed")]
            public bool Indexed { get; set; }

            [JsonPropertyName("internalType")]
            public string InternalType { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
        public class Output
        {
            [JsonPropertyName("internalType")]
            public string InternalType { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
    }
}

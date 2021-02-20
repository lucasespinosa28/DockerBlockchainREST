using DockerBlockchainRest.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace DockerBlockchainRest.Controllers
{
    public static class ReadAbi
    {
        public static List<ContractClass.Result> DeserializedAbi() => JsonSerializer.Deserialize<List<ContractClass.Result>>(AbiJson.readFile());
    }
}

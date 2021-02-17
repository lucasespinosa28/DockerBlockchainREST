using DockerRESTBlockchain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.Controllers
{
    public static class ReadAbi
    {
        public static List<ContractClass.Result> DeserializedAbi() => JsonSerializer.Deserialize<List<ContractClass.Result>>(JsonExample.Abi);
    }
}

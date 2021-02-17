using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Contracts;
using DockerRESTBlockchain.Models;
using Nethereum.Web3;
using System.Text.Json;
using Nethereum.ABI.FunctionEncoding;

namespace DockerRESTBlockchain.Controllers
{
    public class Connect
    {
        private static Web3 Web { get; set; } = new Web3("https://bsc-dataseed.binance.org/");
        public Contract GetContract() => Web.Eth.GetContract(JsonExample.Abi, "0xbb4CdB9CBd36B01bD1cBaEBF2De08d9173bc095c");

        //List<JsonObjects.Example> result = JsonSerializer.Deserialize<List<JsonObjects.Example>>(Contract.Abi);
       
        public async Task<List<ParameterOutput>> Outputs(string name)
        {
            var contract = GetContract().GetFunction(name);
            return await contract.CallDecodingToDefaultAsync();
        }
        public Output OutputsToJson(List<ParameterOutput> parameters)
        {
            if (parameters.Count == 1)
            {
                return new Output { Results = parameters[0].Result.ToString(), Success = true };
            }
            Dictionary<object, object> valuePairs = new Dictionary<object, object>();
            foreach (var parameter in parameters)
            {
                valuePairs.Add(parameter.Parameter.Name.ToString(), parameter.Result.ToString());
            }
            return new Output { Results = valuePairs, Success = true };
        }
        
        //"type": "object",
        //"properties": {

        //"additionalProperties": {}
       
    }
}

using DockerBlockchainRest.Models;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace DockerBlockchainRest.Controllers
{
    public class Connect
    {
        public static bool TestNet { get; set; } = false;
        private static Web3 Web { get; set; } = new Web3("https://bsc-dataseed.binance.org/");
        public Connect()
        {
            if (TestNet)
            {
                Web = new Web3("https://data-seed-prebsc-1-s1.binance.org:8545");
            }
        }
        public Nethereum.Contracts.Contract GetContract() => Web.Eth.GetContract(AbiJson.readFile(), Address.hash);

        public async Task<List<ParameterOutput>> Outputs(string name)
        {
            var contract = GetContract().GetFunction(name);
            return await contract.CallDecodingToDefaultAsync();
        }
        public async Task<BigInteger> CurrentBlockAsync() => await Web.Eth.Blocks.GetBlockNumber.SendRequestAsync();

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
    }
}

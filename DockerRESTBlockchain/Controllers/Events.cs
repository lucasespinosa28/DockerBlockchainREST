using Microsoft.AspNetCore.Mvc;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Event : Controller
    {
        [HttpGet("{name}")]
        public async Task<ActionResult> IndexAsync(string name)
        {
            var blocks = new Connect();
            BigInteger currentBlock = blocks.CurrentBlockAsync().Result;
            BigInteger oldblocks = currentBlock - BigInteger.Parse(HttpContext.Request.Query["NumberBlocks"]);

            var transferEventHandler = blocks.GetContract().GetEvent(name);
            var cBlock = new BlockParameter(new HexBigInteger(currentBlock));
            var oBlock = new BlockParameter(new HexBigInteger(oldblocks));
            var filterAllTransferEventsForContract = transferEventHandler.CreateFilterInput(oBlock, cBlock);
            var allTransferEventsForContract = await transferEventHandler.GetAllChangesDefault(filterAllTransferEventsForContract);
            var result = new List<Dictionary<object, object>>();
            foreach (var item in allTransferEventsForContract)
            {

                var ResultEvent = new Dictionary<object, object>();
                foreach (var item1 in item.Event)
                {
                    ResultEvent.Add(item1.Parameter.Name, item1.Result.ToString());
                }
                result.Add(ResultEvent);


            }
            return Ok(result);
        }
    }
}

using DockerRESTBlockchain.Models;
using DockerRESTBlockchain.SwaggerGenerator;
using DockerRESTBlockchain.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadContract : ControllerBase
    {
        [HttpGet("{function}")]
        public async Task<ActionResult> GetfunctionAsync(string function)
        {
            var queryString = HttpContext.Request.Query;
            if (HttpContext.Request.Query.Count != 0)
            {
                var objects = new object[HttpContext.Request.Query.Count];
              
                var index = 0;
                foreach (var item in HttpContext.Request.Query)
                {
                    objects[index] = item.Value;
                    index++;
                }
                return Ok(objects);
            }
            var block = new Connect();
            Dictionary<object, object> Resul = new Dictionary<object, object>();
            foreach (var item in ReadAbi.DeserializedAbi())
            {
                if (item.StateMutability == "view" && item.Inputs.Count == 0)
                {
                    if (item.Name.Contains(function))
                    {
                        var contract = block.GetContract().GetFunction(item.Name);
                        var outputs = await contract.CallDecodingToDefaultAsync();
                        foreach (var output in outputs)
                        {
                            BigInteger number1;
                            BigInteger.TryParse(output.Result.ToString(), out number1);
                            object name = "string";
                            object outPutResult = output.Result;
                            if (output.Parameter.Name == "")
                            {
                                if (TestType.IsAddress(output.Result.ToString()))
                                {
                                    name = "address";
                                }
                                if (BigInteger.TryParse(output.Result.ToString(), out number1))
                                {
                                    name = "number";
                                }
                            }

                            //var number = BigInteger.TryParse(output.Result.ToString(), out number1) ? number1 : new BigInteger(0);
                            //var name = TestType.IsAddress(output.Result.ToString()) ? "address" : "result";
                            
                            Resul.Add(name, output.Result.ToString());

                        }
                        return Ok(Resul);
                    }
                }
            }
            return NotFound();
        }
        [HttpPost("{function}/{paramenters}")]
        public async Task<ActionResult> PostfunctionAsync(string function, [FromBody] string text)
        {
            var result = $"{function}{text}";
            var block = new Connect();
            foreach (var item in ReadAbi.DeserializedAbi()) 
            {
                if (item.Inputs.Count > 0)
                {
                    return Ok(result);
                }
            }
            return NotFound();
        }
        [HttpGet("swagger")]
        public ActionResult GetCustomSwagger()
        {
          
            var file = new CreateFile();
            var result = file.keyValuePairs();
            return new JsonResult(result);
        }
    }
}

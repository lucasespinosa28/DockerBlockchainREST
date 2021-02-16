using DockerRESTBlockchain.Models;
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
            foreach (var item in block.DeserializedAbi())
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
                            object name = output.Parameter.Name;
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
        [HttpPost("{function}")]
        public async Task<ActionResult> PostfunctionAsync(string function, [FromBody] string text)
        {
            var result = $"{function}{text}";
            var block = new Connect();
            foreach (var item in block.DeserializedAbi()) 
            {
                if (item.Inputs.Count > 0)
                {
                    return Ok(result);
                }
            }
                //var queryString = HttpContext.Request.Query;
                //if (HttpContext.Request.Query.Count != 0)
                //{
                //    var objects = new object[HttpContext.Request.Query.Count];

                //    var index = 0;
                //    foreach (var item in HttpContext.Request.Query)
                //    {
                //        objects[index] = item.Value;
                //        index++;
                //    }
                //}
            return NotFound();
        }
        [HttpGet("swagger")]
        public ActionResult GetCustomSwagger()
        {
            //Dictionary<object, SwaggerJson.ComponentSchemas> pairs = new Dictionary<object, SwaggerJson.ComponentSchemas>();
            //pairs.Add("OutputText", new SwaggerJson.ComponentSchemas { Type = "object", additionalProperties = false });
            var block = new Connect();
            //var result = new SwaggerJson
            //{
            //    openapi = "3.0.1",
            //    info = new SwaggerJson.Info { version = "v1", title = "Docker rest blockchain" },
            //    paths = block.keyValuePairs(),
            //    components = block.componentsInside()
            //};
            //SwaggerJson.componentsInside test = new SwaggerJson.componentsInside { schemas = pairs };
            //result.components = test;
            //result.servers.Add(new SwaggerJson.Server { url = "localhost:49153" });
            //Dictionary<object, object> dictionaries = block.keyValuePairs();
            var result = block.keyValuePairs();
            return new JsonResult(result);
        }
        //{
            //  "openapi": "3.0.1",
            //  "info": {
            //    "title": "DockerRESTBlockchain",
            //    "version": "v1"
            //  },
            //  "servers": [
            //    {
            //      "url": "https://localhost:49153"
            //    }
            //  ]
            //}
    }
}

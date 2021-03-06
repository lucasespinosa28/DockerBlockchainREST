﻿using DockerBlockchainRest.SwaggerGenerator;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace DockerBlockchainRest.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReadContract : ControllerBase
    {
        [HttpGet("{function}")]
        public async Task<ActionResult> GetfunctionAsync(string function)
        {
            var querys = HttpContext.Request.Query;
            var paramenters = new object[querys.Count];
            if (querys.Count > 0)
            {
                var index = 0;
                foreach (var item in querys)
                {
                    if (Utils.TestType.IsNumber(item.Value))
                    {
                        paramenters[index] = BigInteger.Parse(item.Value);
                    }
                    else
                    {
                        paramenters[index] = item.Value.ToString();
                    }
                    index++;
                }
            }
            var block = new Connect();
            Dictionary<object, object> Resul = new Dictionary<object, object>();
            foreach (var item in GetPaths.Contracts)
            {
                if (item.Contains(function))
                {
                    var contract = block.GetContract().GetFunction(function);
                    var outputs = await contract.CallDecodingToDefaultAsync(paramenters);
                    if (outputs.Count == 1)
                    {
                        Resul.Add("result", outputs[0].Result.ToString());
                    }
                    else
                    {
                        foreach (var output in outputs)
                        {
                            Resul.Add(output.Parameter.Name, output.Result.ToString());
                        }
                    }
                    return Ok(Resul);
                }
            }
            return NotFound();
        }
        [HttpGet("swagger")]
        public ActionResult GetCustomSwagger()
        {
            var result = Swagger.GenerateFile();
            return new JsonResult(result);
        }
    }
}

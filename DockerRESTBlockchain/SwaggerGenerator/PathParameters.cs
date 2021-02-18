using DockerRESTBlockchain.SwaggerGenerator.Models;
using System.Collections.Generic;

namespace DockerRESTBlockchain.SwaggerGenerator
{
    public partial class Swagger
    {

        private static List<Parameter> PathParameters(List<DockerRESTBlockchain.Models.ContractClass.Input> inputs, bool isEvent)
        {
            var listparameters = new List<Parameter>();
            int InputImdex = 1;
            if (isEvent)
            {
                listparameters.Add(new Parameter { @in = "query", name = "NumberBlocks", required = false, schema = new ParameterSchema { type = "number", format = "uint256" } });
                return listparameters;
            }
            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                if (input.Name == "")
                {
                    input.Name = $"{input.Type}{InputImdex}";
                    InputImdex++;
                }
                if (input.Type.Contains("int"))
                {
                    input.Type = "number";
                }
                if (input.Type.Contains("address"))
                {
                    input.Type = "string";
                }
                listparameters.Add(new Parameter { @in = "query", name = input.Name, required = true, schema = new ParameterSchema { type = input.Type, format = input.Type } });
            }
            return listparameters;
        }
    }
}
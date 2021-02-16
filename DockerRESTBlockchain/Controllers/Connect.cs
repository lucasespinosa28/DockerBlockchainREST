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
        public List<ContractClass.Result> DeserializedAbi() => JsonSerializer.Deserialize<List<ContractClass.Result>>(JsonExample.Abi);
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
        public class urls
        {
            public string url { get; set; }
        }
        public class MethodGet
        {
            public string[] tags { get; set; }
            public Dictionary<object, object> responses { get; set; }
        }
        public class MethodGetWithParameters
        {
            public string[] tags { get; set; }
            public int parameters { get; set; }
            public Dictionary<object, object> responses { get; set; }
        }
        public class MethodStatus
        {
            public string description { get; set; }
            public Dictionary<object, object> content { get; set; }
        }
        public class MethodSchema
        {
            public string description { get; set; }
            public Dictionary<object, object> content { get; set; }
        }
        public class ComponentsSchame
        {
            public string type { get; set; }
            public Dictionary<object, object> properties { get; set; }
            public bool additionalProperties { get; set; }
        }
        //"type": "object",
        //"properties": {

        //"additionalProperties": {}
        public Dictionary<object, object> keyValuePairs()
        {
            var swaggerBody = new Dictionary<object, object>();
            swaggerBody.Add("openapi","3.0.1");

            var swaggerInfo = new Dictionary<object, object>();
            swaggerInfo.Add("title", "BlockchainRest");
            swaggerInfo.Add("description", "Blockchain rest");
            swaggerInfo.Add("version", "v1");
            swaggerBody.Add("info", swaggerInfo);

            var url = new urls[1] { new urls { url = "https://localhost:49157" } };
            swaggerBody.Add("servers", url);

            var swaggerPaths = new Dictionary<object, object>();
            var swaggerComponentsName = new Dictionary<object, object>();
            var swaggerComponentsSchame = new Dictionary<object, object>();
            foreach (var item in DeserializedAbi())
            {
                if (item.StateMutability == "view")
                {
                    var swaggerPathsMethod = new Dictionary<object, object>();
                    var swaggerPathsMethodResponses = new Dictionary<object, object>();
                    var swaggerPathsMethodcontent = new Dictionary<object, object>();
                    var swaggerPathsMethodSchema = new Dictionary<object, object>();
                    var swaggerPathsMethodSchemaref = new Dictionary<object, object>();
                                   
                    swaggerPathsMethodSchemaref.Add("$ref", $"#/components/schemas/{item.Name}");
                    swaggerPathsMethodSchema.Add("schema",swaggerPathsMethodSchemaref);
                    swaggerPathsMethodcontent.Add("text/plain", swaggerPathsMethodSchema);
                    swaggerPathsMethodcontent.Add("pplication/json", swaggerPathsMethodSchema);
                    swaggerPathsMethodcontent.Add("text/json", swaggerPathsMethodSchema);
                    var status = new MethodStatus();
                    status.description = "Success";
                    status.content = swaggerPathsMethodcontent;
                    swaggerPathsMethodResponses.Add("200", status);
                    if (item.Inputs.Count == 0)
                    {
                        var getContent = new MethodGet();
                        getContent.tags = new string[1] { "readcontract" };
                        getContent.responses = swaggerPathsMethodResponses;
                        swaggerPathsMethod.Add("get", getContent);
                        swaggerPaths.Add($"/api/readcontract/{item.Name}", swaggerPathsMethod);

                    }
                    else
                    {
                        var getContent = new MethodGetWithParameters();
                        getContent.tags = new string[1] { "readcontract" };
                        getContent.responses = swaggerPathsMethodResponses;
                        swaggerPathsMethod.Add("get", getContent);
                        swaggerPaths.Add($"/api/readcontract/{item.Name}/{{paramenters}}", swaggerPathsMethod);
                    }
                    var swaggerComponentsSchameProperties = new Dictionary<object, object>();
                    var swaggerComponentsSchamePropertiesType = new Dictionary<object, object>();
                    foreach (var Output in item.Outputs)
                    {
                        if (Output.Name == "")
                        {
                            if (item.Outputs.Count >= 0)
                            {
                                Output.Name = "Result";
                            }
                            else
                            {
                                for (int i = 0; i < item.Outputs.Count; i++)
                                {
                                    Output.Name = $"Output{i}";

                                }
                            }
                        }
                        if (Output.Type.Contains("int"))
                        {
                            Output.Type = "number";
                        }
                        if (Output.Type.Contains("address"))
                        {
                            Output.Type = "string";
                        }
                        swaggerComponentsSchamePropertiesType.Add("type", Output.Type);
                        swaggerComponentsSchameProperties.Add(Output.Name, swaggerComponentsSchamePropertiesType);
                    }
                    var Schame = new ComponentsSchame
                    {
                        type = "object",
                        properties = swaggerComponentsSchameProperties,
                        additionalProperties = false
                    };
                    swaggerComponentsName.Add(item.Name, Schame);

                }
            }
            swaggerBody.Add("paths", swaggerPaths);

            swaggerComponentsSchame.Add("schemas", swaggerComponentsName);
            swaggerBody.Add("components", swaggerComponentsSchame);

            return swaggerBody;
            //Dictionary<object, Dictionary<object, SwaggerJson.method>> valuePairs = new Dictionary<object, Dictionary<object, SwaggerJson.method>>();
            //foreach (var item in DeserializedAbi())
            //{
            //    if (item.StateMutability == "view")
            //    {

            //        var ListParamenters = new List<SwaggerJson.paramenter>();
            //        if (item.Inputs.Count != 0)
            //        {
            //            foreach (var input in item.Inputs)
            //            {
            //                if (input.Type.Contains("int"))
            //                {
            //                    input.Type = "number";
            //                }
            //                if (input.Type.Contains("address"))
            //                {
            //                    input.Type = "string";
            //                }
            //                ListParamenters.Add(
            //                    new SwaggerJson.paramenter
            //                    {
            //                        name = $"{input.Name}",
            //                        @in = "query",
            //                        schema = new SwaggerJson.Schema { type = input.Type }
            //                    });
            //            }
            //        }


            //        Dictionary<object, SwaggerJson.method> dictionaries = new Dictionary<object, SwaggerJson.method>();
            //        Dictionary<object, SwaggerJson.Response> dictionaries1 = new Dictionary<object, SwaggerJson.Response>();
            //        Dictionary<object, object> dictionaries2 = new Dictionary<object, object>();

            //        Dictionary<string, string> refecendeDicnarie = new Dictionary<string, string>();
            //        refecendeDicnarie.Add("$ref", $"#/components/schemas/{item.Name}Output");

            //        Dictionary<string, Dictionary<string, string>> schemaDicnarie = new Dictionary<string, Dictionary<string, string>>();
            //        schemaDicnarie.Add("schema", refecendeDicnarie);

            //        dictionaries2.Add("text/plain", schemaDicnarie);

            //        dictionaries2.Add("application/json", schemaDicnarie);
            //        dictionaries2.Add("text/json", schemaDicnarie);
            //        dictionaries1.Add("200", new SwaggerJson.Response { description = "Success", content = dictionaries2 });
            //        if (item.Inputs.Count == 0)
            //        {
            //            dictionaries.Add("get", new SwaggerJson.method
            //            {
            //                tags = new string[] { "ReadContract" },
            //                parameters = ListParamenters,
            //                responses = dictionaries1
            //            });
            //        }
            //        else
            //        {
            //            Dictionary<object, object> contentDic = new Dictionary<object, object>();
            //            Dictionary<object, SwaggerJson.RequestBodytype> propertiesDic = new Dictionary<object, SwaggerJson.RequestBodytype>();

            //            var testIndex = 1;
            //            foreach (var output in item.Outputs)
            //            {

            //                if (output.Name == "")
            //                {
            //                    output.Name = $"input{testIndex}";
            //                }
            //                testIndex++;
            //                propertiesDic.Add(output.Name, new SwaggerJson.RequestBodytype { type = output.Type });
            //            }
            //            testIndex = 1;



            //            var test55 = new SwaggerJson.RequestBodySchame { type = "object", properties = propertiesDic };

            //            contentDic.Add("application/json", test55);
            //            dictionaries.Add("post", new SwaggerJson.method
            //            {
            //                tags = new string[] { "ReadContract" },
            //                parameters = ListParamenters,
            //                requestBody = new SwaggerJson.RequestBody { required = true,content = contentDic}
            //            });
            //        }
            //        valuePairs.Add($"/api/ReadContract/{item.Name}", dictionaries);
            //    }

            //}
            //return valuePairs;
        }
        public SwaggerJson.componentsInside componentsInside()
        {
            Dictionary<object, SwaggerJson.ComponentSchemas> pairs = new Dictionary<object, SwaggerJson.ComponentSchemas>();
            foreach (var item in DeserializedAbi())
            {
                if (item.StateMutability == "view")
                {
                    Dictionary<object, SwaggerJson.ComponentSchemasproperties> propertiesDictionary = new Dictionary<object, SwaggerJson.ComponentSchemasproperties>();
                    var test = new Dictionary<object, SwaggerJson.ComponentSchemasproperties>();

                    //foreach (var output in item.Outputs)
                    //{
                    //    propertiesDictionary.Add(output.Name, new SwaggerJson.ComponentSchemasproperties { Type = output.Type});
                    //    if (output.Name == "")
                    //    {
                    //        output.Name = $"{output.Type}{outputIndex}";
                    //        outputIndex++;
                    //    }
                    //    //test.Add(output.Name, output.Type);
                    //}
                    int ouputIndex = 1;
                    foreach (var output in item.Outputs)
                    {
                        if (output.Name == "")
                        {
                            output.Name = $"{output.Type}-{ouputIndex}";
                            ouputIndex++;
                        }
                        if (output.Type.Contains("int"))
                        {
                            output.Type = "number";
                        }
                        if (output.Type.Contains("address"))
                        {
                            output.Type = "string";
                        }
                        test.Add(output.Name, new SwaggerJson.ComponentSchemasproperties { type = output.Type});

                    }
                pairs.Add($"{item.Name}Output", new SwaggerJson.ComponentSchemas { type = "object", properties = test, additionalProperties = false });
                } 
            }
            return new SwaggerJson.componentsInside { schemas = pairs };
        }
    }
}

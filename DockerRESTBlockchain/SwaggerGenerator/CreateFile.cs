using DockerRESTBlockchain.Controllers;
using DockerRESTBlockchain.SwaggerGenerator.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DockerRESTBlockchain.Utils;

namespace DockerRESTBlockchain.SwaggerGenerator
{
    public class CreateFile
    {
        public Dictionary<object, object> keyValuePairs()
        {
            var swaggerBody = new Dictionary<object, object>();
            swaggerBody.Add("openapi", "3.0.1");
            swaggerBody.Add("info", Swagger.Info());
            var swaggerPaths = new Dictionary<object, object>();
            var swaggerComponentsName = new Dictionary<object, object>();
            var swaggerComponentsSchame = new Dictionary<object, object>();
            foreach (var item in ReadAbi.DeserializedAbi())
            {
                if (item.StateMutability == "view" | item.Type.Equals("event"))
                {
                    var swaggerPathsMethod = new Dictionary<object, object>();
                    var swaggerPathsMethodResponses = new Dictionary<object, object>();
                    var swaggerPathsMethodcontent = new Dictionary<object, object>();
                    var swaggerPathsMethodSchema = new Dictionary<object, object>();
                    var swaggerPathsMethodSchemaref = new Dictionary<object, object>();

                    swaggerPathsMethodSchemaref.Add("$ref", $"#/components/schemas/{item.Name}");
                    swaggerPathsMethodSchema.Add("schema", swaggerPathsMethodSchemaref);
                    swaggerPathsMethodcontent.Add("text/plain", swaggerPathsMethodSchema);
                    swaggerPathsMethodcontent.Add("pplication/json", swaggerPathsMethodSchema);
                    swaggerPathsMethodcontent.Add("text/json", swaggerPathsMethodSchema);
                    var status = new PathStatus();
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
                        int InputImdex = 1;
                        var listparameters = new List<Parameter>();
                        List<DockerRESTBlockchain.Models.ContractClass.Input> tadsad = item.Inputs;
                        foreach (var input in item.Inputs)
                        {

                            if (input.Name == "")
                            {
                                input.Name = $"{input.Type}{InputImdex}";
                                InputImdex++;
                            }
                            var test = new Parameter();
                            test.required = true;
                            test.@in = "query";
                            test.name = input.Name;
                            var schameType = "";
                            if (input.Type.Contains("int"))
                            {
                                schameType = "number";
                            }
                            if (input.Type.Contains("address"))
                            {
                                schameType = "string";
                            }
                            test.schema = new ParameterSchema { format = input.Type, type = schameType };
                            listparameters.Add(test);
                        }

                        InputImdex = 1;
                        List<Parameter> testsa = listparameters;
                        getContent.parameters = listparameters;
                        swaggerPathsMethod.Add("get", getContent);
                        swaggerPaths.Add($"/api/readcontract/{item.Name}", swaggerPathsMethod);
                    }


                }
            }
            
            swaggerBody.Add("paths", SwaggerPaths());

            swaggerComponentsSchame.Add("schemas", swaggerComponentsName);
            swaggerBody.Add("components", Swagger.Components());

            return swaggerBody;

        }

        private static Dictionary<object, object> SwaggerPaths()
        {
            var Paths = new Dictionary<object, object>();

            ReadAbi.DeserializedAbi().ForEach((item) =>
            {
                if (item.StateMutability == "view" | item.Type.Equals("event"))
                {
                    var Method = new Dictionary<object, object>();
                    var isEvent = item.Type.Equals("event") ? "event" : "readcontract";
                    Dictionary<object, object> test = PathsResponses(item.Name);
                    var Count = item.Inputs.Count;
                    if (item.Type.Equals("event"))
                    {
                        Count = 0;
                    }
                    Method.Add("get", HasPramenters(Count, new string[1] { $"{isEvent}s"}, PathsResponses(item.Name), PathParameters(item.Inputs, item.Type.Equals("event")), item.Type.Equals("event")));
                    Paths.Add($"/api/{isEvent}/{item.Name}", Method);
                }
            });
            return Paths;
        }
        public static dynamic HasPramenters(int count,string[] tags, Dictionary<object, object> responses, List<Parameter> parameters ,bool isEvent)
        {
            if (count == 0 && !isEvent)
            {
                return  new MethodGet() { tags = tags, responses = responses };
            }
            return new MethodGetWithParameters() { tags = tags, responses = responses, parameters = parameters };
        }
        private static Dictionary<object, object>PathsResponses(string pathName)
        {
            var Reference = new Dictionary<object, object>();
            var Content = new Dictionary<object, object>();
            var Schema = new Dictionary<object, object>();
            var Responses = new Dictionary<object, object>();

            Reference.Add("$ref", $"#/components/schemas/{pathName}");
            Schema.Add("schema", Reference);
            Content.Add("text/plain", Schema);
            Content.Add("pplication/json", Schema);
            Content.Add("text/json", Schema);
            Responses.Add("200", new PathStatus { description = "Success", content = Content });
            return Responses;
        }
        public static List<Parameter> PathParameters(List<DockerRESTBlockchain.Models.ContractClass.Input> inputs, bool isEvent)
        {
            var listparameters = new List<Parameter>();
            int InputImdex = 1;
            if (isEvent)
            {
                listparameters.Add(new Parameter { @in = "query", name = "NumberBlocks", required = false, schema = new ParameterSchema { type = "Number", format = "uint256" } });
                return listparameters;
            }
            foreach (var input in inputs)
            {

                if (input.Name == "")
                {
                    input.Name = $"{input.Type}{InputImdex}";
                    InputImdex++;
                }
               listparameters.Add(new Parameter { @in = "query",name = input.Name , required = true,schema = new ParameterSchema { type = "test", format = "test" } });
            }
            return listparameters;
        }

        public void newJson()
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/", "swagger.json");
            string FileContent = JsonSerializer.Serialize(keyValuePairs());
            File.WriteAllText(FilePath, FileContent);
        }

    }
}

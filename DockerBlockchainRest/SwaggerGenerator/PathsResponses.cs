using DockerBlockchainRest.SwaggerGenerator.Models;
using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public partial class Swagger
    {

        private static Dictionary<object, object> PathsResponses(string pathName)
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
    }
}
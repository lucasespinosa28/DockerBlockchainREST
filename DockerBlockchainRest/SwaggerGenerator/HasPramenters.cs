using DockerBlockchainRest.SwaggerGenerator.Models;
using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public partial class Swagger
    {

        private static dynamic HasPramenters(int count, string[] tags, Dictionary<object, object> responses, List<Parameter> parameters, bool isEvent)
        {
            if (count == 0 && !isEvent)
            {
                return new MethodGet() { tags = tags, responses = responses };
            }
            return new MethodGetWithParameters() { tags = tags, responses = responses, parameters = parameters };
        }
    }
}
using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public partial class Swagger
    {

        private static Dictionary<object, object> Info()
        {
            var swaggerInfo = new Dictionary<object, object>();
            swaggerInfo.Add("title", "BlockchainRest");
            swaggerInfo.Add("description", "Rest API generated using abi contract.");
            swaggerInfo.Add("version", "v1");
            return swaggerInfo;
        }
    }
}
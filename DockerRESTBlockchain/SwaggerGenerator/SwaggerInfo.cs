using System.Collections.Generic;

namespace DockerRESTBlockchain.SwaggerGenerator
{
    public partial class Swagger
    {

        public static Dictionary<object, object> Info()
        {
            var swaggerInfo = new Dictionary<object, object>();
            swaggerInfo.Add("title", "BlockchainRest");
            swaggerInfo.Add("description", "blablabl");
            swaggerInfo.Add("version", "v1");
            return swaggerInfo;
        }
    }
}
using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public partial class Swagger
    {

        public static Dictionary<object, object> GenerateFile()
        {
            var swaggerBody = new Dictionary<object, object>();
            swaggerBody.Add("openapi", "3.0.1");
            swaggerBody.Add("info", Info());

            var swaggerComponentsName = new Dictionary<object, object>();
            var swaggerComponentsSchame = new Dictionary<object, object>();



            swaggerBody.Add("paths", SwaggerPaths());
            swaggerComponentsSchame.Add("schemas", swaggerComponentsName);
            swaggerBody.Add("components", Components());

            return swaggerBody;

        }
    }
}
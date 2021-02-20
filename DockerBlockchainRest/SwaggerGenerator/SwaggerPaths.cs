using DockerBlockchainRest.Controllers;
using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public partial class Swagger
    {

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
                    Method.Add("get", HasPramenters(Count, new string[1] { $"{isEvent}s" }, PathsResponses(item.Name), PathParameters(item.Inputs, item.Type.Equals("event")), item.Type.Equals("event")));
                    Paths.Add($"/api/{isEvent}/{item.Name}", Method);


                }
            });
            return Paths;
        }
    }
}
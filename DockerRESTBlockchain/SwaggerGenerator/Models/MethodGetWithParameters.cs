using System.Collections.Generic;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class MethodGetWithParameters
    {
        public string[] tags { get; set; }
        public List<Parameter> parameters { get; set; }
        public Dictionary<object, object> responses { get; set; }
    }
}

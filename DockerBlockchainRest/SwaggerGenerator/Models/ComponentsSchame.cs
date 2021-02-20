using System.Collections.Generic;

namespace DockerBlockchainRest.SwaggerGenerator.Models
{
    public class ComponentsSchame
    {
        public string type { get; set; }

        public Dictionary<object, object> properties { get; set; }
        public bool additionalProperties { get; set; }
    }
}

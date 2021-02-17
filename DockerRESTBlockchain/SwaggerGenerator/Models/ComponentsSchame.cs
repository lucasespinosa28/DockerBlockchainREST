using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class ComponentsSchame
    {
        public string type { get; set; }

        public Dictionary<object, object> properties { get; set; }
        public bool additionalProperties { get; set; }
    }
}

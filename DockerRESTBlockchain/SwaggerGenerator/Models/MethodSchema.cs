using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class MethodSchema
    {
        public string description { get; set; }
        public Dictionary<object, object> content { get; set; }
    }
}

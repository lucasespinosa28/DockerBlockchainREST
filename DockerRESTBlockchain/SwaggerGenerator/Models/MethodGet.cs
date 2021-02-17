using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class MethodGet
    {
        public string[] tags { get; set; }
        public Dictionary<object, object> responses { get; set; }
    }
}

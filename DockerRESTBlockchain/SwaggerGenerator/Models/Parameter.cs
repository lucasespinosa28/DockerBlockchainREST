using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class Parameter
    {
        public string name { get; set; }
        public string @in { get; set; }
        public bool required { get; set; }
        public ParameterSchema schema { get; set; }
    }
}

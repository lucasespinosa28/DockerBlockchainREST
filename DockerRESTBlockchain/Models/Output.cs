using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain.Models
{
    public class Output
    {
        public object Results { get; set; }
        public bool Success { get; set; }
    }
    public class OutputText
    {
        public string Results { get; set; }
        public bool Success { get; set; }
    }
}

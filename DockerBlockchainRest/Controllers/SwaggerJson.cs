using System.Collections.Generic;

namespace DockerBlockchainRest.Controllers
{
    public class SwaggerJson
    {


        public string openapi { get; set; }
        public Info info { get; set; }
        public List<Server> servers { get; set; } = new List<Server>();

        public class Info
        {
            public string title { get; set; }
            public string version { get; set; }
        }

        public class Server
        {
            public string url { get; set; }
        }
        public Dictionary<object, Dictionary<object, method>> paths { get; set; }

        public componentsInside components { get; set; }
        public class componentsInside
        {
            public Dictionary<object, ComponentSchemas> schemas { get; set; }
        }

        //public Dictionary<object, ComponentSchemas> schemas { get; set; }

        public class ComponentSchemas
        {
            public string type { get; set; }
            public Dictionary<object, ComponentSchemasproperties> properties { get; set; }
            public bool additionalProperties { get; set; }
        }
        public class ComponentSchemasproperties
        {
            public string type { get; set; }
        }
        //"type": "string",
        //  "nullable": true
        //{
        //"type": "object",
        //"properties": {
        //  "results": {
        //    "type": "string",
        //    "nullable": true
        //  },
        //  "success": {
        //    "type": "boolean"
        //  }
        //},
        //"additionalProperties": false
        //}

        public class method
        {
            public string[] tags { get; set; }
            public List<paramenter>? parameters { get; set; }
            public Dictionary<object, Response> responses { get; set; }
            public RequestBody requestBody { get; set; }
        }
        public class paramenter
        {
            public string name { get; set; }
            public string @in { get; set; }
            public Schema schema { get; set; }
        }

        public class RequestBody
        {
            public bool required { get; set; }
            public Dictionary<object, object> content { get; set; }
        }
        public class RequestBodySchame
        {
            public string type { get; set; }
            public Dictionary<object, RequestBodytype> properties { get; set; }
        }
        public class RequestBodytype
        {
            public string type { get; set; }
        }

        public class Schema
        {
            public string type { get; set; }
        }
        public class Response
        {
            public string description { get; set; }
            public Dictionary<object, object> content { get; set; }

        }
    }

}

﻿using System.Collections.Generic;

namespace DockerRESTBlockchain.SwaggerGenerator.Models
{
    public class MethodSchema
    {
        public string description { get; set; }
        public Dictionary<object, object> content { get; set; }
    }
}

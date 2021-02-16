using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerRESTBlockchain
{
    public static class CustomSchema
    {
        public static void PrimitiveTypes(this SwaggerGenOptions c)
        {
            static OpenApiSchema Schema(string type, string format)
            {
                var schema = new OpenApiSchema() { Type = type, Format = format };
                return schema;
            }

            c.MapType<int>(() => Schema("integer", "int32"));
            c.MapType<long>(() => Schema("integer", "int64"));
            c.MapType<float>(() => Schema("number", "float"));
            c.MapType<double>(() => Schema("number", "double"));
            c.MapType<byte>(() => Schema("string", "byte"));
        }
    }
}

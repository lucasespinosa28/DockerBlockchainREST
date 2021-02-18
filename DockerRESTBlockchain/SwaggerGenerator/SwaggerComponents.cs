using DockerRESTBlockchain.Controllers;
using DockerRESTBlockchain.SwaggerGenerator.Models;
using System.Collections.Generic;

namespace DockerRESTBlockchain.SwaggerGenerator
{
    public partial class Swagger
    {
        private static Dictionary<object, object> Components()
        {
            var ComponentsSchemas = new Dictionary<object, object>();
            var ComponentsNames = new Dictionary<object, object>();
            var ComponentsProperties = new Dictionary<object, object>();
            foreach (var item in ReadAbi.DeserializedAbi())
            {
                var ComponentsTypes = new Dictionary<object, object>();
                if (item.StateMutability == "view")
                {

                    GetPaths.Contracts.Add(item.Name);
                    item.Outputs.ForEach((output) =>
                    {
                        if (output.Name == "")
                        {
                            output.Name = "result";
                        }
                        ComponentsTypes.Add(output.Name, new ComponentsProperties { type = output.Type, format = output.Type });
                    });
                    if (item.Name != null)
                    {
                        ComponentsNames.Add(item.Name, new ComponentsSchame { type = "object", properties = ComponentsTypes, additionalProperties = false });
                    }

                }
                if (item.Type == "event")
                {
                    GetPaths.Events.Add(item.Name);
                    item.Inputs.ForEach((output) =>
                    {
                        if (output.Name == "")
                        {
                            output.Name = "result";
                        }
                        ComponentsTypes.Add(output.Name, new ComponentsProperties { type = output.Type, format = output.Type });
                    });
                    if (item.Name != null)
                    {
                        ComponentsNames.Add(item.Name, new ComponentsSchame { type = "object", properties = ComponentsTypes, additionalProperties = false });
                    }

                }
            }
            ComponentsSchemas.Add("schemas", ComponentsNames);

            return ComponentsSchemas;
        }
    }
}
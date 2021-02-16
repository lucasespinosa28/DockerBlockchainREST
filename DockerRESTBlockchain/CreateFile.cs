using DockerRESTBlockchain.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DockerRESTBlockchain
{
    public class CreateFile
    {
        public void newJson()
        {
            var block = new Connect();
            //var result = new SwaggerJson
            //{
            //    openapi = "3.0.1",
            //    info = new SwaggerJson.Info { version = "v1", title = "Docker rest blockchain" },
            //    paths = block.keyValuePairs(),
            //    components = block.componentsInside()
            //};
            //result.servers.Add(new SwaggerJson.Server { url = @"https://localhost:49157" });
            //string FilePath = System.Web.HttpUtility.UrlEncode(@"wwwroot/FILENAME.json");
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/", "swagger.json");
            string FileContent = JsonSerializer.Serialize(block.keyValuePairs());
            File.WriteAllText(FilePath, FileContent);
        }
    }
}

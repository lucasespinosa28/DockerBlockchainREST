using System.IO;
using System.Text.Json;

namespace DockerBlockchainRest.SwaggerGenerator
{
    public class CreateFile
    {

        public void newJson()
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/swagger", "swagger.json");
            string FileContent = JsonSerializer.Serialize(Swagger.GenerateFile());
            File.WriteAllText(FilePath, FileContent);
        }

    }
}

using System.IO;

namespace DockerRESTBlockchain.Models
{
    public static class AbiJson
    {
        public static string readFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/storage/abi.json");
            string result = File.Exists(path) ? File.ReadAllText(path) : JsonExample.Abi;
            return result;
        }
    }
}

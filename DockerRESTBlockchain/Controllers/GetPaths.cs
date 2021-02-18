using System.Collections.Generic;

namespace DockerRESTBlockchain.Controllers
{
    public static class GetPaths
    {
        public static List<string> Contracts { get; set; } = new List<string>();
        public static List<string> Events { get; set; } = new List<string>();
    }
}

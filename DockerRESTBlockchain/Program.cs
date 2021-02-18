using CommandLine;
using DockerRESTBlockchain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DockerRESTBlockchain
{
    public class Options
    {
        [Option('a', "address", Required = true, HelpText = "Contract Address.")]
        public string Address { get; set; }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                 .WithParsed<Options>(o =>
                 {
                     Address.hash = o.Address;
                 });
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

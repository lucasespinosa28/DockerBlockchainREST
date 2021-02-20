using CommandLine;
using DockerBlockchainRest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DockerBlockchainRest
{
    public class Options
    {
        [Option('a', "address", Required = true, HelpText = "Contract Address.")]
        public string Address { get; set; }

        [Option('t', "testnet", Required = false, HelpText = "Is in testnet.")]
        public bool TestNet { get; set; }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                 .WithParsed<Options>(o =>
                 {
                     Controllers.Connect.TestNet = o.TestNet;
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

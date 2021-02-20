namespace DockerBlockchainRest.SwaggerGenerator.Models
{
    public class Parameter
    {
        public string name { get; set; }
        public string @in { get; set; }
        public bool required { get; set; }
        public ParameterSchema schema { get; set; }
    }
}

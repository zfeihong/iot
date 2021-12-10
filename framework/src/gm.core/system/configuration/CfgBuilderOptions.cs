using System.Reflection;

namespace gm.system.configuration
{
    public class CfgBuilderOptions
    {
        public Assembly UserSecretsAssembly { get; set; }

        public string UserSecretsId { get; set; }

        public string FileName { get; set; } = "appsettings";
 
        public string EnvironmentName { get; set; }

        public string BasePath { get; set; }
 
        public string EnvironmentVariablesPrefix { get; set; }

        public string[] CommandLineArgs { get; set; }
    }
}

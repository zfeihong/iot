using gm.system.extentions;
using Microsoft.Extensions.Configuration;

namespace gm.system.configuration
{
    public static class CfgHelper
    {
        public static IConfigurationRoot BuildConfiguration(
            CfgBuilderOptions options = null,
            Action<IConfigurationBuilder> builderAction = null)
        {
            options = options ?? new CfgBuilderOptions();

            if (options.BasePath.IsNullOrEmpty())
                options.BasePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(options.BasePath)
                .AddJsonFile(options.FileName + ".json", optional: true, reloadOnChange: true);

            if (!options.EnvironmentName.IsNullOrEmpty())
            {
                builder = builder.AddJsonFile($"{options.FileName}.{options.EnvironmentName}.json", optional: true, reloadOnChange: true);
            }

            if (options.EnvironmentName == "Development")
            {
                if (options.UserSecretsId != null)
                    builder.AddUserSecrets(options.UserSecretsId);
                else if (options.UserSecretsAssembly != null)
                    builder.AddUserSecrets(options.UserSecretsAssembly, true);
            }

            builder = builder.AddEnvironmentVariables(options.EnvironmentVariablesPrefix);

            if (options.CommandLineArgs != null)
                builder = builder.AddCommandLine(options.CommandLineArgs);

            builderAction?.Invoke(builder);

            return builder.Build();
        }
    }
}


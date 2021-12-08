using gm.system.extentions;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.core
{
    public class AppInServiceProvider : AppBase, IAppInServiceProvider
    {
        public IServiceScope ServiceScope { get; private set; }

        public AppInServiceProvider(
            [NotNull] Type startupModule,
            [CanBeNull] Action<AppCreationOptions> optionsAction
            ) : base(
                startupModule,
                new ServiceCollection(),
                optionsAction)
        {
            base.Services.AddSingleton<IAppInServiceProvider>(this);
        }

        public void Initialize()
        {
            this.ServiceScope = base.Services.BuildServiceProviderFromFactory().CreateScope();
            base.SetServiceProvider(ServiceScope.ServiceProvider);

            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
            ServiceScope.Dispose();
        }
    }
}

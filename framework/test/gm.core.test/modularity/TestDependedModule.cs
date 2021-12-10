using gm.modularity;
using gm.modularity.test;

namespace gm.test.modularity
{
    public class TestDependedModule : TestModuleBaba
    {
        public override void PreCfgServices(ServiceCfgContext context)
        {
            base.PreCfgServices(context);

            SkipAutoServiceRegistration = true;
        }

        public override void PostCfgServices(ServiceCfgContext context)
        {
            base.PostCfgServices(context);
        }

        public override void OnAppInit(AppInitContext context)
        {
            base.OnAppInit(context);
        }
    }
}

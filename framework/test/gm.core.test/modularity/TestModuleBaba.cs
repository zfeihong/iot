using System;
using System.Collections.Generic;
using System.Linq;

namespace gm.modularity.test
{
    public class TestModuleBaba : ModuleBaba
    {
        public bool PreConfigureServicesIsCalled { get; set; }

        public bool ConfigureServicesIsCalled { get; set; }

        public bool PostConfigureServicesIsCalled { get; set; }

        public bool OnApplicationInitializeIsCalled { get; set; }

        public bool OnApplicationShutdownIsCalled { get; set; }

        public override void PreCfgServices(ServiceCfgContext context)
        {
            PreConfigureServicesIsCalled = true;
        }

        public override void CfgService(ServiceCfgContext context)
        {
            ConfigureServicesIsCalled = true;
        }

        public override void PostCfgServices(ServiceCfgContext context)
        {
            PostConfigureServicesIsCalled = true;
        }

        public override void OnAppInit(AppInitContext context)
        {
            OnApplicationInitializeIsCalled = true;
        }

        public override void OnAppShutdown(AppShutdownContext context)
        {
            OnApplicationShutdownIsCalled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace gm.modularity.test
{
    public class TestModuleBaba : ModuleBaba
    {
        public bool PreCfgServicesIsCalled { get; set; }

        public bool CfgServicesIsCalled { get; set; }

        public bool PostCfgServicesIsCalled { get; set; }

        public bool OnAppInitisCalled { get; set; }

        public bool OnAppShutdownIsCalled { get; set; }

        public override void PreCfgServices(ServiceCfgContext context)
        {
            PreCfgServicesIsCalled = true;
        }

        public override void CfgService(ServiceCfgContext context)
        {
            CfgServicesIsCalled = true;
        }

        public override void PostCfgServices(ServiceCfgContext context)
        {
            PostCfgServicesIsCalled = true;
        }

        public override void OnAppInit(AppInitContext context)
        {
            OnAppInitisCalled = true;
        }

        public override void OnAppShutdown(AppShutdownContext context)
        {
            OnAppShutdownIsCalled = true;
        }
    }
}

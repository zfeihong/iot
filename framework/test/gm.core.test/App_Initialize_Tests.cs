using gm.system.extentions;
using gm.test.modularity;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace gm.core.test
{
    public class App_Initialize_Tests
    {
        [Fact]
        public void Should_Initialize_Single_Module()
        {
            using (var app = AppFactory.Create<TestDependedModule>())
            {
                //Assert
                var module = app.Services.GetSingletonInstance<TestDependedModule>();
                module.PreConfigureServicesIsCalled.ShouldBeTrue();
                module.ConfigureServicesIsCalled.ShouldBeTrue();
                module.PostConfigureServicesIsCalled.ShouldBeTrue();

                //Act
                app.Initialize();

                //Assert
                app.ServiceProvider.GetRequiredService<TestDependedModule>().ShouldBeSameAs(module);
                module.OnApplicationInitializeIsCalled.ShouldBeTrue();

                //Act
                app.Shutdown();

                //Assert
                module.OnApplicationShutdownIsCalled.ShouldBeTrue();
            }
        }

        //[Fact]
        //public void Should_Initialize_PlugIn()
        //{
        //    using (var application = AppFactory.Create<TestDependedModule>(options =>
        //    {
        //        options.PlugInList.AddTypes(typeof(TestDependedPlugInModule));
        //    }))
        //    {
        //        //Assert
        //        var plugInModule = application.Services.GetSingletonInstance<TestDependedPlugInModule>();
        //        plugInModule.PreConfigureServicesIsCalled.ShouldBeTrue();
        //        plugInModule.ConfigureServicesIsCalled.ShouldBeTrue();
        //        plugInModule.PostConfigureServicesIsCalled.ShouldBeTrue();

        //        //Act
        //        application.Initialize();

        //        //Assert
        //        application.ServiceProvider.GetRequiredService<TestDependedPlugInModule>().ShouldBeSameAs(plugInModule);
        //        plugInModule.OnApplicationInitializeIsCalled.ShouldBeTrue();

        //        //Act
        //        application.Shutdown();

        //        //Assert
        //        plugInModule.OnApplicationShutdownIsCalled.ShouldBeTrue();
        //    }
        //}
    }
}

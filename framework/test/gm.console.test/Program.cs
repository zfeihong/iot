using gm.core;
using gm.system.extentions;
using gm.test.modularity;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

Console.WriteLine("Hello, World!");

using (var app = AppFactory.Create<TestDependedModule>())
{
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
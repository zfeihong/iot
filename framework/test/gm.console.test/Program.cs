using gm.core;
using gm.di;
using gm.guid;
using gm.modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using (var application = AppFactory.Create<MyConsoleModule>())
{
    Console.WriteLine("Initializing the application...");
    application.Initialize();
    Console.WriteLine("Initializing the application... OK");

    //Console.WriteLine("Checking configuration...");

    //var configuration = application.ServiceProvider.GetRequiredService<IConfiguration>();
    //if (configuration["AppSettingKey1"] != "AppSettingValue1")
    //{
    //    Console.WriteLine("ERROR: Could not read the configuration!");
    //    Console.WriteLine("Press ENTER to exit!");
    //    Console.ReadLine();
    //    return;
    //}

    //Console.WriteLine();
    //Console.WriteLine("Checking configuration... OK");

    var writers = application.ServiceProvider.GetServices<IMessageWriter>();

    foreach (var writer in writers)
    {
        writer.Write();
    }

    Console.WriteLine();
    Console.WriteLine("Press ENTER to exit!");
    Console.ReadLine();
}

[Rely(typeof(GmGuidsModule))]
public class MyConsoleModule : ModuleBaba
{

}

public interface IMessageWriter
{
    void Write();
}

public class ConsoleMessageWriter : IMessageWriter, ITransientDependency
{
    protected IGuidGenerator _guidGenerator { get; }
    private readonly MessageSource _messageSource;

    public ConsoleMessageWriter(MessageSource messageSource, IGuidGenerator guidGenerator)
    {
        _messageSource = messageSource;
        _guidGenerator = guidGenerator;
    }

    public void Write()
    {
        Console.WriteLine(_guidGenerator.Create());
        Console.WriteLine(_messageSource.GetMessage());
    }
}

public class MessageSource : ITransientDependency
{
    public string GetMessage()
    {
        return "Hello Jackyfei!";
    }
}
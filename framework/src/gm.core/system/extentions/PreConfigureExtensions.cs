
namespace gm.system.extentions
{
     public static class PreConfigureExtensions
    {
        //public static IServiceCollection PreConfigure<TOptions>(this IServiceCollection services, Action<TOptions> optionsAction)
        //{
        //    services.GetPreConfigureActions<TOptions>().Add(optionsAction);
        //    return services;
        //}

        //public static TOptions ExecutePreConfiguredActions<TOptions>(this IServiceCollection services)
        //    where TOptions : new()
        //{
        //    return services.ExecutePreConfiguredActions(new TOptions());
        //}

        //public static TOptions ExecutePreConfiguredActions<TOptions>(this IServiceCollection services, TOptions options)
        //{
        //    services.GetPreConfigureActions<TOptions>().Configure(options);
        //    return options;
        //}

        //public static PreConfigureActionList<TOptions> GetPreConfigureActions<TOptions>(this IServiceCollection services)
        //{
        //    var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<PreConfigureActionList<TOptions>>>()?.Value;
        //    if (actionList == null)
        //    {
        //        actionList = new PreConfigureActionList<TOptions>();
        //        services.AddObjectAccessor(actionList);
        //    }

        //    return actionList;
        //}
    }
}

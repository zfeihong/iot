using gm.modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Spi;

namespace gm.quartz
{
    public class GmQuartzModule : ModuleBaba
    {
        private IScheduler _scheduler;

        public override void CfgService(ServiceCfgContext context)
        {
            //var options = context.Services.ExecutePreConfiguredActions<QuartzOptions>();
            //context.Services.AddSingleton(AsyncHelper.RunSync(() => new StdSchedulerFactory(options.Properties).GetScheduler()));
            context.Services.AddSingleton(typeof(IJobFactory), typeof(JobFactory));

            Configure<QuartzOptions>(quartzOptions =>
            {
                //quartzOptions.Properties = options.Properties;
                //quartzOptions.StartDelay = options.StartDelay;
            });
        }

        public override void OnAppInit(AppInitContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<QuartzOptions>>().Value;

            //_scheduler = context.ServiceProvider.GetService<IScheduler>();
            //_scheduler.JobFactory = context.ServiceProvider.GetService<IJobFactory>();

            //AsyncHelper.RunSync(() => options.StartSchedulerFactory.Invoke(_scheduler));
        }

        public override void OnAppShutdown(AppShutdownContext context)
        {
            if (_scheduler.IsStarted)
            {
                //AsyncHelper.RunSync(() => _scheduler.Shutdown());
            }
        }
    }
}
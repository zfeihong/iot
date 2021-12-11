
using Quartz;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace gm.quartz
{
    public class QuartzOptions
    {   
        /// <summary>
        /// The quartz configuration. Available properties can be found within Quartz.Impl.StdSchedulerFactory.
        /// </summary>
        public NameValueCollection Properties { get; set; }

        /// <summary>
        /// How long Quartz should wait before starting. Default: 0.
        /// </summary>
        public TimeSpan StartDelay { get; set; }

        [NotNull]
        public Func<IScheduler, Task> StartSchedulerFactory
        {
            get => _startSchedulerFactory;
            set => _startSchedulerFactory = value;
        }

        private Func<IScheduler, Task> _startSchedulerFactory;

        public QuartzOptions()
        {
            Properties = new NameValueCollection();
            StartDelay = new TimeSpan(0);
            _startSchedulerFactory = StartSchedulerAsync;
        }

        private async Task StartSchedulerAsync(IScheduler scheduler)
        {
            if (StartDelay.Ticks > 0)
                await scheduler.StartDelayed(StartDelay);
            else
                await scheduler.Start();
        }
    }
}
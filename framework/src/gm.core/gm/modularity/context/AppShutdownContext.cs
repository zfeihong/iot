using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gm.modularity
{
    public class AppShutdownContext
    {
        public IServiceProvider ServiceProvider { get; }

        public AppShutdownContext([NotNull] IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}

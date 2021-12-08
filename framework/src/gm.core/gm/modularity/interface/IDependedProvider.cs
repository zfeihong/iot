using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gm.modularity
{
    public interface IDependedProvider
    {
        [NotNull]
        Type[] GetDependeds();
    }
}

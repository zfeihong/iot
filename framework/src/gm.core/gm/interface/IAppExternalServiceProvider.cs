using JetBrains.Annotations;
 
namespace gm.core
{
    public interface IAppExternalServiceProvider : IApp
    {
        void Initialize([NotNull] IServiceProvider serviceProvider);
    }
}

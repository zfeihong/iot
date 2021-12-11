using JetBrains.Annotations;

namespace gm.modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RelyAttribute : Attribute, IRelyOnProvider
    {
        [NotNull]
        public Type[] types { get; }

        public RelyAttribute(params Type[] types)
        {
            types = types ?? new Type[0];
        }

        public Type[] GetRelyOnTypes()
        {
            return types;
        }
    }
}

using gm.di;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace gm.serialization
{
    public class DefaultSerializer : ISerializer, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultSerializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual byte[] Serialize<T>(T obj)
        {
            if (obj == null) return null;

            using (var scope = _serviceProvider.CreateScope())
            {
                var specificSerializer = scope.ServiceProvider.GetService<ISerializer<T>>();
                if (specificSerializer != null)
                    return specificSerializer.Serialize(obj);
            }

            return AutoSerialize(obj);
        }

        [CanBeNull]
        public virtual T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null) return default;

            using (var scope = _serviceProvider.CreateScope())
            {
                var specificSerializer = scope.ServiceProvider.GetService<ISerializer<T>>();
                if (specificSerializer != null) return specificSerializer.Deserialize(bytes);
            }

            return AutoDeserialize<T>(bytes);
        }

        protected virtual byte[] AutoSerialize<T>(T obj)
        {
            return BinarySerializationHelper.Serialize(obj);
        }

        protected virtual T AutoDeserialize<T>(byte[] bytes)
        {
            return (T)BinarySerializationHelper.DeserializeExtended(bytes);
        }
    }
}

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace gm.serialization
{
    public static class BinarySerializationHelper
    {
        public static byte[] Serialize(object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                CreateBinaryFormatter().Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static void Serialize(object obj, Stream stream)
        {
            CreateBinaryFormatter().Serialize(stream, obj);
        }

        public static object Deserialize(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                return CreateBinaryFormatter().Deserialize(memoryStream);
            }
        }

        public static object Deserialize(Stream stream)
        {
            return CreateBinaryFormatter().Deserialize(stream);
        }

        public static object DeserializeExtended(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                return CreateBinaryFormatter(true).Deserialize(memoryStream);
            }
        }
 
        public static object DeserializeExtended(Stream stream)
        {
            return CreateBinaryFormatter(true).Deserialize(stream);
        }

        private static BinaryFormatter CreateBinaryFormatter(bool extended = false)
        {
            if (extended)
            {
                return new BinaryFormatter
                {
                    Binder = new ExtendedSerializationBinder()
                };
            }
            else
            {
                return new BinaryFormatter();
            }
        }

        private sealed class ExtendedSerializationBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                var toAssemblyName = assemblyName.Split(',')[0];
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.FullName.Split(',')[0] == toAssemblyName)
                    {
                        return assembly.GetType(typeName);
                    }
                }

                return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
            }
        }
    }
}

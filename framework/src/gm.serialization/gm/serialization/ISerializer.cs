namespace gm.serialization
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T obj);

        T Deserialize<T>(byte[] bytes);
    }

    public interface ISerializer<T>
    {
        byte[] Serialize(T obj);

        T Deserialize(byte[] bytes);
    }
}
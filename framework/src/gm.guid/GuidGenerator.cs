
namespace gm.guid
{
    public class SimpleGuidGenerator : IGuidGenerator
    {
        private SimpleGuidGenerator() { }

        public static SimpleGuidGenerator Instance { get; } = new SimpleGuidGenerator();

        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}

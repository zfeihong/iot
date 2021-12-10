
namespace gm.system.extentions
{
    public static class ObjectExtensions
    {
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }
    }
}

using System.Collections.Generic;

namespace Presentation.Core
{
    /// <summary>
    /// Enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        public static void AddTo<T>(this T item, ICollection<T> collection)
        {
            collection.Add(item);
        }
    }
}
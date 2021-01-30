using System.Collections.Generic;

namespace HouseBuild
{
    public static class ListExtends
    {
        public static List<T> Flip<T>(this List<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex == secondIndex) return list;
            var buffer = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = buffer;
            return list;
        }
    }
}

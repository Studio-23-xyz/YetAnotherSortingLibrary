using System;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    public static class SortDotNet<T> where T:IComparable<T>
    {
        public static T[] Sort(T[] data,SortType sortType,SortOrder order=default)
        {
            SortFactory<T> factory = new SortFactory<T>();
            ISort<T> sorter = factory.GetSort(sortType);
            return sorter.Sort(data, order);
        }
    }
}

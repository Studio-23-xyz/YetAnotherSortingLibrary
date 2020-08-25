using System;
using DTD.Sort.Net.Enums;

namespace DTD.Sort.Net.Interfaces
{
    public interface ISort<T> where T:IComparable<T>
    {
         T[] Sort(T[] input, SortOrder sortOrder=SortOrder.Default);
    }
}

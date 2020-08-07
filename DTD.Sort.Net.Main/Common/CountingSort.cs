using System;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    internal class CountingSort<T>: ISort<T> where T:IComparable<T>
    {
       
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using System.Collections.Generic;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using DTD.Sort.Net.Main.Sorts;

namespace DTD.Sort.Net.Main
{
    internal class SortFactory<T> where T:IComparable<T>
    {
        private Dictionary<SortType, ISort<T>> SortLibrary;

        public SortFactory()
        {
            SortLibrary = new Dictionary<SortType, ISort<T>>();
            
            SortLibrary.Add(SortType.Bubble, new BubbleSort<T>());
        }

        public ISort<T> GetSort(SortType type) => SortLibrary[type];

    }
}

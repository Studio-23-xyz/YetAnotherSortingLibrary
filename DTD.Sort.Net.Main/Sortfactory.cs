using System;
using System.Collections.Generic;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    internal class SortFactory<T> where T:IComparable<T>
    {
        public Dictionary<SortType, ISort<T>> SortLibrary;

        public SortFactory()
        {
            SortLibrary = new Dictionary<SortType, ISort<T>>();

            SortLibrary.Add(SortType.Quick, new QuickSort<T>());
            SortLibrary.Add(SortType.Bubble, new BubbleSort<T>());
            SortLibrary.Add(SortType.Selection, new SelectionSort<T>());
            SortLibrary.Add(SortType.Insertion, new InsertionSort<T>());
            SortLibrary.Add(SortType.Counting, new CountingSort<T>());
            SortLibrary.Add(SortType.Merge, new MergeSort<T>());

        }

        public ISort<T> GetSort(SortType type) => SortLibrary[type];

    }
}

using System;
using System.Collections.Generic;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    internal class SortFactory<T> where T:IComparable<T>
    {
        public readonly Dictionary<SortType, ISort<T>> SortLibrary;

        public SortFactory()
        {
            SortLibrary = new Dictionary<SortType, ISort<T>>
            {
                {SortType.Quick, new QuickSort<T>()},
                {SortType.Bubble, new BubbleSort<T>()},
                {SortType.Selection, new SelectionSort<T>()},
                {SortType.Insertion, new InsertionSort<T>()},
                {SortType.Merge, new MergeSort<T>()},
                {SortType.Cocktail, new CocktailSort<T>()}
            };


        }

        public ISort<T> GetSort(SortType type) => SortLibrary[type];

    }
}

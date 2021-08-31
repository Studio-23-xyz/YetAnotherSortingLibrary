using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;


namespace DTD.Sort.Net.Algorithms.Uncommons
{
    public class StoogeSort<T> : ISort<T> where T : IComparable<T>
    {
        public SortType Type => SortType.Stooge;

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            if (input.Length > 1)
            {
                Stooging(input, 0, input.Length - 1,sortOrder);
            }

            return input;
        }


        private  void Stooging(T[] L, int i, int j, SortOrder order)
        {
            if (Compare(L[j],L[i],order))
            {
                T tmp = L[i];
                L[i] = L[j];
                L[j] = tmp;
            }
            if (j - i > 1)
            {
                int t = (j - i + 1) / 3;
                Stooging(L, i, j - t,order);
                Stooging(L, i + t, j,order);
                Stooging(L, i, j - t,order);
            }
        }

        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Ascending ? difference < 0 : difference > 0;
        }



    }
}

using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;

namespace DTD.Sort.Net.Main
{
    internal class ShellSort<T> : ISort<T> where T : IComparable<T>
    {

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            int n = input.Length;
            int h = 1;

            while (h < (n >> 1))
            {
                h = (h << 1) + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    int k = i - h;
                    for (int j = i; j >= h && Compare(input[j], input[k], sortOrder); k -= h)
                    {



                        T temp = input[j];

                        input[j] = input[k];
                        input[k] = temp;
                        j = k;

                    }
                }
                h >>= 1;
            }
            return input;
        }
        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Ascending ? difference < 0 : difference > 0;
        }


    }
}


using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DTD.Sort.Net.Main
{

    internal class GnomeSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            int first = 1;
            int second = 2;

            while (first < input.Length)
            {
                var a = first;
                if (Compare(input[first - 1], input[first], sortOrder))
                {
                    
                    first = second;
                    second++;
                }
                else
                {
                    var tmp = input[first - 1];
                    input[first - 1] = input[first];
                    input[first] = tmp;
                    first -= 1;
                    if (first == 0)
                    {
                        first = 1;
                        second = 2;
                    }


                }
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

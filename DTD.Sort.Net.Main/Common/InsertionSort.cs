using System;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    public class InsertionSort<T> :ISort<T> where T : IComparable<T> 
    {

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {

            for (int i = 1; i < input.Length; i++)
            {
                var key = input[i];
                int j = i - 1;
                while (j >= 0 &&  Compare(input[j],key,sortOrder))
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = key;
            }

            return input;
        }

        

        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Decending ? difference < 0 : difference > 0;
        }
    }
}

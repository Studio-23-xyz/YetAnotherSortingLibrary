using System;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    public class SelectionSort<T> :ISort<T> where T : IComparable<T> 
    {

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var k = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (Compare(input[j],input[k],sortOrder))
                    {
                        k = j;
                    }
                }

                Swap(ref input[i],ref input[k]);
               
            }

            return input;
        }

        private void Swap(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Decending ? difference > 0 : difference < 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    internal class CocktailSort<T>:ISort<T> where  T:IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i <= input.Length - 2; i++)
                {
                    if(Compare(input[i],input[i+1],sortOrder))
                    {
                        //test whether the two elements are in the wrong order
                        Swap(ref input[i], ref input[i + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    //we can exit the outer loop here if no swaps occurred.
                    break;
                }
                swapped = false;
                for (int i = input.Length - 2; i >= 0; i--)
                {
                    if (Compare(input[i], input[i + 1], sortOrder))
                    {
                        Swap(ref input[i],ref input[i+1]);
                        swapped = true;
                    }
                }
                //if no elements have been swapped, then the list is sorted
            } while (swapped);

            return input;
        }


        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Decending ? difference < 0 : difference > 0;
        }

        private void Swap(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

    }
}

using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTD.Sort.Net.Main
{
    internal class HeapSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            return Sort(input, 0, input.Length,sortOrder);
            
        }


        private T [] Sort(T[] array, int offset, int length,SortOrder sortOrder)
        {
            // build binary heap from all items
            for (int i = 0; i < length; i++)
            {
                int index = i;
                T item = array[offset + i]; // use next item

                // and move it on top, if greater than parent
                while (index > 0 &&
                    Compare(array[offset + (index - 1) / 2], item,sortOrder) )
                {
                    int top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }

            for (int i = length - 1; i > 0; i--)
            {
                // delete max and place it as last
                T last = array[offset + i];
                array[offset + i] = array[offset];

                int index = 0;
                // the last one positioned in the heap
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;

                    if (right < i && Compare(array[offset + left], array[offset + right],sortOrder))
                    {
                        if (Compare(array[offset + right],last, sortOrder)) break;

                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (Compare(array[offset + left], last,sortOrder)) break;

                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
            return array;
        }


        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Ascending ? difference < 0 : difference > 0;
        }
    } 
}

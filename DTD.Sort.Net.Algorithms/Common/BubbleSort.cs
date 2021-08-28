﻿using System;
using System.Runtime.CompilerServices;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

[assembly: InternalsVisibleTo("DTD.Sort.Net.Main")]
namespace DTD.Sort.Net.Algorithms
{
    internal class BubbleSort<T>: ISort<T> where T:IComparable<T>
    {
        public SortType Type => SortType.Bubble;

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length - 1; j++)
                {
                    if (Compare(input[j], input[j + 1], sortOrder))
                    {
                        var temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;
                    }
                }
            }

            return input;
        }

        private bool Compare(T left,T right,SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Decending ? difference < 0 : difference > 0;
        }


    }
}

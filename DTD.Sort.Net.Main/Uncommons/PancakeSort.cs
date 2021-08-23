using System;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main.Uncommons
{
    internal class PancakeSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            
            if (input.Length < 2)
            {
                return input;
            }
            int i, a, max_num_pos;

            for (i = input.Length; i > 1; i--)
            {
                max_num_pos = 0;
                for (a = 0; a < i; a++)
                {
                    
                    if (Compare(input[a], input[max_num_pos],sortOrder))
                    {
                        max_num_pos = a;
                    }

                }
                if (max_num_pos == i - 1)
                {
                    continue;
                }
                if (max_num_pos > 0)
                {
                   Flip(input, input.Length, max_num_pos + 1);
                }
                Flip(input, input.Length, i);
            }

            return input;
        }

        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Decending ? difference < 0 : difference > 0;
        }

        private void Flip<T>(T[] list, int length, int num)
        {
            for (int i = 0; i < --num; i++)
            {
                T swap = list[i];
                list[i] = list[num];
                list[num] = swap;
            }

        }


    }
}

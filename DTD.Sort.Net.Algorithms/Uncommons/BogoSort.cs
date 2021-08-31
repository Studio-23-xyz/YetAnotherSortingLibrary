using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTD.Sort.Net.Algorithms.Uncommons
{
    public class BogoSort<T> : ISort<T> where T : IComparable<T>
    {
        public SortType Type => SortType.Bogo;

        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
           

            while(isSorted(input, sortOrder))
            {
                Shuffle(input);
            }

            return input;

        }
        private  bool isSorted(T[] list,SortOrder sortOrder) 
        {
            if (list.Length <= 1)
                return true;
            for (int i = 1; i < list.Length; i++)
            {
                //if (list[i].CompareTo(list[i - 1]) < 0) return false;
                return Compare(list[i], list[i - 1], sortOrder);
            }
                
            return true;
        }

       

        private  void Shuffle(T[] list)
        {
            Random rand = new Random();
            for (int i = 0; i < list.Length; i++)
            {
                int swapIndex = rand.Next(list.Length);
                T temp = list[swapIndex];
                list[swapIndex] = list[i];
                list[i] = temp;
            }
        }

        private bool Compare(T left, T right, SortOrder order)
        {
            var difference = left.CompareTo(right);

            return order == SortOrder.Ascending ? difference < 0 : difference > 0;
        }

    }
}

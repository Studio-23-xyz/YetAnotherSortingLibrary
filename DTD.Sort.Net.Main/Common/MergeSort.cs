using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;

namespace DTD.Sort.Net.Main
{
    public class MergeSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            var entries2 = new T[input.Length];
            Sort(input, entries2, 0, input.Length - 1, sortOrder);
            return input;
        }

        #region Constants
        private const int mergesDefault = 6;
        private const int insertionLimitDefault = 12;
        #endregion

        #region Properties

        private int[] Positions { get; set; }

        private int _merges;

        private int Merges
        {
            get { return _merges; }
            set
            {
                // A minimum of 2 merges are required
                if (value > 1)
                    _merges = value;
                else
                    throw new ArgumentOutOfRangeException();

                if (Positions == null || Positions.Length != _merges)
                    Positions = new int[_merges];
            }
        }

        private int InsertionLimit { get; set; }
        #endregion

        #region Constructors
        public MergeSort(int merges, int insertionLimit)
        {
            Merges = merges;
            InsertionLimit = insertionLimit;
        }

        public MergeSort()
          : this(mergesDefault, insertionLimitDefault)
        {
        }
        #endregion

        #region Sort Methods


        // Top-Down K-way Merge Sort
        private void Sort(T[] entries1, T[] entries2, int first, int last, SortOrder order)
        {
            var length = last + 1 - first;
            if (length < 2)
                return;
            else if (length < InsertionLimit)
            {
                new InsertionSort<T>().Sort(entries1, order);
                return;
            }

            var left = first;
            var size = ceiling(length, Merges);
            for (var remaining = length; remaining > 0; remaining -= size, left += size)
            {
                var right = left + Math.Min(remaining, size) - 1;
                Sort(entries1, entries2, left, right, order);
            }

            Merge(entries1, entries2, first, last);
            Array.Copy(entries2, first, entries1, first, length);
        }
        #endregion

        #region Merge Methods

        private void Merge(T[] entries1, T[] entries2, int first, int last)
        {
            Array.Clear(Positions, 0, Merges);
            // This implementation has a quadratic time dependency on the number of merges
            for (var index = first; index <= last; index++)
                entries2[index] = Remove(entries1, first, last);
        }

        private T Remove(T[] entries, int first, int last)
        {
            var entry = default(T);
            var found = (int?)null;
            var length = last + 1 - first;

            var index = 0;
            var left = first;
            var size = ceiling(length, Merges);
            for (var remaining = length; remaining > 0; remaining -= size, left += size, index++)
            {
                var position = Positions[index];
                if (position < Math.Min(remaining, size))
                {
                    var next = entries[left + position];
                    if (!found.HasValue || entry.CompareTo(next) > 0)
                    {
                        found = index;
                        entry = next;
                    }
                }
            }

            // Remove entry
            Positions[found.Value]++;
            return entry;
        }
        #endregion

        #region Math Methods
        private static int ceiling(int numerator, int denominator)
        {
            return (numerator + denominator - 1) / denominator;
        }
        #endregion

    }
}

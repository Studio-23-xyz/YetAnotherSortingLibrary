using System;
using System.Diagnostics;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    public class QuickSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] input, SortOrder sortOrder = SortOrder.Default)
        {
            Sort(input, 0, input.Length - 1,sortOrder);
            return input;
        }

        #region Constants
        private const Int32 InsertionLimitDefault = 12;
        #endregion

        #region Properties

        private Int32 InsertionLimit { get; set; }
        private Random Random { get; set; }
        private T Median { get; set; }

        private Int32 Left { get; set; }
        private Int32 Right { get; set; }
        private Int32 LeftMedian { get; set; }
        private Int32 RightMedian { get; set; }
        #endregion

        #region Constructors
        public QuickSort(Int32 insertionLimit, Random random)
        {
            this.InsertionLimit = insertionLimit;
            this.Random = random;
        }

        public QuickSort(Int32 insertionLimit)
          : this(insertionLimit, new Random())
        {
        }

        public QuickSort()
          : this(InsertionLimitDefault)
        {
        }
        #endregion

        #region Sort Methods
     

        private void Sort(T[] entries, Int32 first, Int32 last,SortOrder order)
        {
            var length = last + 1 - first;
            while (length > 1)
            {
                if (length < InsertionLimit)
                {
                    new InsertionSort<T>().Sort(entries,order);
                    return;
                }

                Left = first;
                Right = last;
                Pivot(entries,order);
                Partition(entries);
                //[Note]Right < Left

                var leftLength = Right + 1 - first;
                var rightLength = last + 1 - Left;

                //
                // First recurse over shorter partition, then loop
                // on the longer partition to elide tail recursion.
                //
                if (leftLength < rightLength)
                {
                    Sort(entries, first, Right,order);
                    first = Left;
                    length = rightLength;
                }
                else
                {
                    Sort(entries, Left, last,order);
                    last = Right;
                    length = leftLength;
                }
            }
        }

        private void Pivot(T[] entries,SortOrder order)
        {
            //
            // An odd sample size is chosen based on the log of the interval size.
            // The median of a randomly chosen set of samples is then returned as
            // an estimate of the true median.
            //
            var length = Right + 1 - Left;
            var logLen = (Int32)Math.Log10(length);
            var pivotSamples = 2 * logLen + 1;
            var sampleSize = Math.Min(pivotSamples, length);
            var last = Left + sampleSize - 1;
            // Sample without replacement
            for (var first = Left; first <= last; first++)
            {
                // Random sampling avoids pathological cases
                var random = Random.Next(first, Right + 1);
                Swap(entries, first, random);
            }

            new InsertionSort<T>().Sort(entries,order);
            Median = entries[Left + sampleSize / 2];
        }

        private void Partition(T[] entries)
        {
            int first;
            int last;
#if Tripartite
      LeftMedian = first;
      RightMedian = last;
#endif
            while (true)
            {
                //[Assert]There exists some index >= Left where entries[index] >= Median
                //[Assert]There exists some index <= Right where entries[index] <= Median
                // So, there is no need for Left or Right bound checks
                while (Median.CompareTo(entries[Left]) > 0) Left++;
                while (Median.CompareTo(entries[Right]) < 0) Right--;

                //[Assert]entries[Right] <= Median <= entries[Left]
                if (Right <= Left) break;

                Swap(entries, Left, Right);
                SwapOut(entries);
                Left++;
                Right--;
                //[Assert]entries[first:Left - 1] <= Median <= entries[Right + 1:last]
            }

            if (Left == Right)
            {
                Left++;
                Right--;
            }
            //[Assert]Right < Left
            SwapIn(entries, first, last);

            //[Assert]entries[first:Right] <= Median <= entries[Left:last]
            //[Assert]entries[Right + 1:Left - 1] == Median when non-empty
        }
        #endregion

        #region Swap Methods
        [Conditional("Tripartite")]
        private void SwapOut(T[] entries)
        {
            if (Median.CompareTo(entries[Left]) == 0) Swap(entries, LeftMedian++, Left);
            if (Median.CompareTo(entries[Right]) == 0) Swap(entries, Right, RightMedian--);
        }

        [Conditional("Tripartite")]
        private void SwapIn(T[] entries, Int32 first, Int32 last)
        {
            // Restore Median entries
            while (first < LeftMedian) Swap(entries, first++, Right--);
            while (RightMedian < last) Swap(entries, Left++, last--);
        }

        private  void Swap(T[] entries, Int32 index1, Int32 index2)
        {
            if (index1 == index2) return;
            var entry = entries[index1];
            entries[index1] = entries[index2];
            entries[index2] = entry;
        }
        #endregion


    }
}

using System.Collections.Generic;
using System.Linq;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using DTD.Sort.Net.Main;
using NUnit.Framework;

namespace DTD.Sort.Net.Tests
{
    public class IntTest
    {
        private int[] UnsortedArray;
        private int[] SortedArray;
        private int[] SortedArrayDescending;


        private static IEnumerable<ISort<int>> TestAssistant =>
            new TestAssistant<int>().GetSortlibrary().Values.ToList();


        [SetUp]
        public void Setup()
        {
            
            UnsortedArray = new[] {1, 5, 6, 2, 4, 3};
            SortedArray = new[] {1, 2, 3, 4, 5, 6};
            SortedArrayDescending = new[] {6, 5, 4, 3, 2, 1};
        }

        [TestCaseSource("TestAssistant")]
        public void RunCases(ISort<int> sort)
        {
            Ascending(sort);
            Descending(sort);
        }

        private void Ascending(ISort<int> sort)
        {
            sort.Sort(UnsortedArray, SortOrder.Ascending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArray);
        }


        private void Descending(ISort<int> sort)
        {
            sort.Sort(UnsortedArray, SortOrder.Decending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArrayDescending);
        }
    }
}
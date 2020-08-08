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
        private int[] _unsortedArray;
        private int[] _sortedArray;
        private int[] _sortedArrayDescending;


        private static IEnumerable<ISort<int>> TestAssistant =>
            new TestAssistant<int>().GetSortlibrary().Values.ToList();


        [SetUp]
        public void Setup()
        {

            _unsortedArray = new[] {1, 5, 6, 2, 4, 3};
            _sortedArray = new[] {1, 2, 3, 4, 5, 6};
            _sortedArrayDescending = new[] {6, 5, 4, 3, 2, 1};
        }

        [TestCaseSource("TestAssistant")]
        public void RunCases(ISort<int> sort)
        {
            Ascending(sort);
            Descending(sort);
        }

        private void Ascending(ISort<int> sort)
        {
            sort.Sort(_unsortedArray, SortOrder.Ascending);
            CollectionAssert.AreEqual(_unsortedArray, _sortedArray);
        }


        private void Descending(ISort<int> sort)
        {
            sort.Sort(_unsortedArray, SortOrder.Decending);
            CollectionAssert.AreEqual(_unsortedArray, _sortedArrayDescending);
        }
    }
}
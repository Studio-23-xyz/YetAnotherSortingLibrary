using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Main;
using NUnit.Framework;

namespace DTD.Sort.Net.Tests
{
    public class IntTest
    {
        private int[] UnsortedArray;
        private int[] SortedArray;
        private int[] SortedArrayDescending;

        [SetUp]
        public void Setup()
        {
            UnsortedArray = new[] { 1, 5, 6, 2, 4, 3 };
            SortedArray = new[] { 1, 2, 3, 4, 5, 6 };
            SortedArrayDescending = new[] { 6,5,4,3,2,1};
        }

        [Test]
        public void Ascending()
        {
            
            SortDotNet<int>.Sort(UnsortedArray,SortType.Bubble,SortOrder.Ascending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArray);
        }

        [Test]
        public void Descending()
        {
            SortDotNet<int>.Sort(UnsortedArray,SortType.Bubble,SortOrder.Decending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArrayDescending);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using DTD.Sort.Net.Main;
using NUnit.Framework;

namespace DTD.Sort.Net.Tests
{
    public class TypeTest<T> where T:IComparable<T>
    {
        private T[] BaseData;
        private T[] UnsortedArray;
        private T[] SortedArray;
        private T[] SortedArrayDescending;


        private static IEnumerable<ISort<T>> TestAssistant => new TestAssistant<T>().GetSortlibrary().Values.ToList();


        public TypeTest(T[] unsortedData,T[] sortedData,T[] sortedDataDesc)
        {
            BaseData = unsortedData;
            SortedArray = sortedData;
            SortedArrayDescending = sortedDataDesc;
        }

        [SetUp]
        public void Setup()
        {
           Array.Copy(BaseData, UnsortedArray, BaseData.Length);
        }

        [TestCaseSource("TestAssistant")]
        public void RunCases(ISort<T> sort)
        {
            Ascending(sort);
            Descending(sort);
        }

        private void Ascending(ISort<T> sort)
        {
            sort.Sort(UnsortedArray, SortOrder.Ascending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArray);
        }

        
        private void Descending(ISort<T> sort)
        {
            sort.Sort(UnsortedArray, SortOrder.Decending);
            CollectionAssert.AreEqual(UnsortedArray, SortedArrayDescending);
        }


    }
}
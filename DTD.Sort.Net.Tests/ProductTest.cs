using System.Collections.Generic;
using System.Linq;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using DTD.Sort.Net.Main;
using NUnit.Framework;

namespace DTD.Sort.Net.Tests
{
    public class ProductTest
    {
        private Product[] _unsortedArray;
        private Product[] _sortedArray;
        private Product[] _sortedArrayDescending;


        private static IEnumerable<ISort<Product>> TestAssistant =>
            new TestAssistant<Product>().GetSortlibrary().Values.ToList();


        [SetUp]
        public void Setup()
        {
            Product product1=new Product(){Cost = 10,Name = "10"};
            Product product2 = new Product() { Cost = 15, Name = "15" };
            Product product3 = new Product() { Cost = 16, Name = "16" };
            Product product4 = new Product() { Cost = 18, Name = "18" };
            Product product5 = new Product() { Cost = 20, Name = "20" };


            _unsortedArray = new Product[5];

            _unsortedArray[0] = product2;
            _unsortedArray[1] = product1;
            _unsortedArray[2] = product4;
            _unsortedArray[3] = product3;
            _unsortedArray[4] = product5;


            _sortedArray = new Product[5];

            _sortedArray[0] = product1;
            _sortedArray[1] = product2;
            _sortedArray[2] = product3;
            _sortedArray[3] = product4;
            _sortedArray[4] = product5;



            _sortedArrayDescending = new Product[5];

            _sortedArrayDescending[0] = product5;
            _sortedArrayDescending[1] = product4;
            _sortedArrayDescending[2] = product3;
            _sortedArrayDescending[3] = product2;
            _sortedArrayDescending[4] = product1;

        }

        [TestCaseSource("TestAssistant")]
        public void RunCases(ISort<Product> sort)
        {
            Ascending(sort);
            Descending(sort);
        }

        private void Ascending(ISort<Product> sort)
        {
            sort.Sort(_unsortedArray, SortOrder.Ascending);
            CollectionAssert.AreEqual(_unsortedArray, _sortedArray);
        }


        private void Descending(ISort<Product> sort)
        {
            sort.Sort(_unsortedArray, SortOrder.Decending);
            CollectionAssert.AreEqual(_unsortedArray, _sortedArrayDescending);
        }
    }
}
using System;
using NUnit.Framework;

namespace DTD.Sort.Net.Tests
{
    public class TestManager
    {
        TypeTest<int> IntTester;

        public TestManager()
        {
            var UnsortedArray = new[] { 1, 5, 6, 2, 4, 3 };
            var SortedArray = new[] { 1, 2, 3, 4, 5, 6 };
            var SortedArrayDescending = new[] { 6, 5, 4, 3, 2, 1 };

            IntTester = new TypeTest<int>(UnsortedArray,SortedArray,SortedArrayDescending);
        }

        [Test]
        public void RunTests()
        {
            //IntTester.RunCases();
        }
    }
}

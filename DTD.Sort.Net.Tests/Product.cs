using System;
using System.Collections.Generic;
using System.Text;

namespace DTD.Sort.Net.Tests
{
    public class Product:IComparable<Product>
    {
        public string Id;
        public string Name;
        public float Cost;
        public float Price;



        public int CompareTo(Product other)
        {
            if (Cost > other.Cost) return 1;
            if (Cost < other.Cost) return -1;
            return 0;
        }
    }
}

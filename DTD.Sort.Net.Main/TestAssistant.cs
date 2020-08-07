using System;
using System.Collections.Generic;
using System.Linq;
using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;

namespace DTD.Sort.Net.Main
{
    public class TestAssistant<T> where T:IComparable<T>
    {
        
        public Dictionary<SortType, ISort<T>> GetSortlibrary()
        {
            return new SortFactory<T>().SortLibrary;
        }
    }
}

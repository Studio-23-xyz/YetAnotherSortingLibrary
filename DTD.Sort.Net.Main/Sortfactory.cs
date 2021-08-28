using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DTD.Sort.Net.Algorithms;

[assembly: InternalsVisibleTo("DTD.Sort.Net.Tests")]
namespace DTD.Sort.Net.Main
{
    internal class SortFactory<T> where T : IComparable<T>
    {
        public readonly List<ISort<T>> SortLibrary;

        public SortFactory()
        {
            SortLibrary = new List<ISort<T>>();
            Assembly algorithmAssembly = Assembly.Load("DTD.Sort.Net.Algorithms");
       
            Type[] algorithms = algorithmAssembly.GetTypes();
            foreach (Type algorithm in algorithms)
            {

                var genericType = algorithm.MakeGenericType(typeof(T));
                var instance = algorithmAssembly.CreateInstance(genericType.FullName);
                SortLibrary.Add((ISort<T>)instance);
            }

        }

        public ISort<T> GetSort(SortType type) => SortLibrary.First(r => r.Type == type);

    }
}

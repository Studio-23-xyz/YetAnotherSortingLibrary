using DTD.Sort.Net.Enums;
using DTD.Sort.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("DTD.Sort.Net.Tests")]
namespace DTD.Sort.Net.Main
{
    internal class SortFactory<T> where T : IComparable<T>
    {

        public readonly Dictionary<SortType,ISort<T>> SortLibrary;
        public SortFactory()
        {

            SortLibrary = new Dictionary<SortType, ISort<T>>();
            Assembly algorithmAssembly = Assembly.Load("DTD.Sort.Net.Algorithms");
       
            Type[] algorithms = algorithmAssembly.GetTypes();
            foreach (Type algorithm in algorithms)
            {

                var genericType = algorithm.MakeGenericType(typeof(T));
                var instance = algorithmAssembly.CreateInstance(genericType.FullName!);
                var iSortInstance = (ISort<T>) instance;

                if (iSortInstance != null) SortLibrary[iSortInstance.Type] = iSortInstance;
            }

        }

       
        public ISort<T> GetSort(SortType type) => SortLibrary[type];

    }
}

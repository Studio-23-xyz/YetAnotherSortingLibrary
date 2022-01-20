Yet Another Sorting Library
================
Just as the name suggests this is just another sorting library for .Net Core. 

[![Security Rating](http://20.188.121.167:9000/api/project_badges/measure?project=YASL&metric=security_rating&token=07b5e775b59803b6ea9e030cc7e82de04f79a651)](http://20.188.121.167:9000/dashboard?id=YASL)
[![Technical Debt](http://20.188.121.167:9000/api/project_badges/measure?project=YASL&metric=sqale_index&token=07b5e775b59803b6ea9e030cc7e82de04f79a651)](http://20.188.121.167:9000/dashboard?id=YASL)


Available Algorithms
================

| Description             | Done | Comment | Description             | Done | Comment |
|-------------------------|------|---------|-------------------------|------|---------|
| Bubble Sort| ✔ |  |Cocktail Sort| ✔ | 
| Insertion Sort| ✔ | |Shell Sort| ✔ |  
| Merge Sort| ✔ | Recursive| Heap Sort| ✔ | 
| Quick Sort| ✔ | Recursive| Gnome Sort| ✔ | 
| Selection Sort| ✔ | |Pancake Sort| ✔ | 







## How to use
```c#
 int[] UnsortedArray = new[] {1, 5, 6, 2, 4, 3};
 SortDotNet<int>.Sort(UnsortedArray, SortType.Bubble, SortOrder.Decending);

```

## Real Use Case

Implement IComparable<T> Interface to your model class

```c#

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

```
Use it just like you would for Base Types

```c#

 SortDotNet<Product>.Sort(UnsortedArray, SortType.Bubble, SortOrder.Decending);

```


Implementation Credits : https://rosettacode.org/wiki/Category:Sorting_Algorithms

Sonarcube wip
 

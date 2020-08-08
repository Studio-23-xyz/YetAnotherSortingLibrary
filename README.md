Yet Another Sorting Library
================
Just as the name suggests this is just another sorting library for .Net Core. 

[![Total alerts](https://img.shields.io/lgtm/alerts/g/Warhammer4000/YetAnotherSortingLibrary.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/Warhammer4000/YetAnotherSortingLibrary/alerts/)
[![Language grade: C#](https://img.shields.io/lgtm/grade/csharp/g/Warhammer4000/YetAnotherSortingLibrary.svg?logo=lgtm&logoWidth=18)](https://lgtm.com/projects/g/Warhammer4000/YetAnotherSortingLibrary/context:csharp)



Available Algorithms
================

| Description             | Done | Comment |
|-------------------------|------|---------|
| Bubble Sort| ✔ | 
| Insertion Sort| ✔ | 
| Merge Sort| ✔ | Recursive
| Quick Sort| ✔ | Recursive
| Selection Sort| ✔ | 
| Cocktail Sort| ✔ | 


## How to use
```c#
 int[] UnsortedArray = new[] {1, 5, 6, 2, 4, 3};
 SortDotNet<int>.Sort(UnsortedArray, SortType.Bubble, SortOrder.Decending);

```





Implementation Credits : https://rosettacode.org/wiki/Category:Sorting_Algorithms

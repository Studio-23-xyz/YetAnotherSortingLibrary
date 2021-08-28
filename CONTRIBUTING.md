# How to add a new sorting algorithm
1. Create a new branch with the name of the sorting algorithm to be added
2. Add your ` {SortingAlgoName}.cs ` file inside ` DTD.Sort.Net.Algorithm `. If it's common put it in common folder otherwise uncommon.
3. Make your class ` internal ` and add ` : ISort<T> where T:IComparable<T> `
4. Implement the interface.
5. Make sure you use the ` sortOrder ` in your implementation.
6. Add your ` sortType ` in ` DTD.Sort.Net.Enums `
7. Run tests
8. If all cases pass create a PR

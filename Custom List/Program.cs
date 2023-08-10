var myList = new CustomList<int>();
// Add.
myList.Add(1);
myList.Add(2);
myList.Add(7);
myList.Add(4);
myList.Add(9);


// Contains.
Console.WriteLine($"Contains 9: {myList.Contains(9)}");
// IndexOf.
Console.WriteLine($"Index of 4: {myList.IndexOf(4)}");
// Count
Console.WriteLine($"Count: {myList.Count}");

// AddRange.
Console.Write("Add Range: ");
myList.AddRange(new List<int>{12, 46, 63});
Display(myList.ToArray());

// CopyTo.
Console.Write("Copied Array: ");
int[] array = new int[myList.Count];
myList.CopyTo(array);
Display(array);

// Insert.
Console.Write("Insert 100 at index 4: ");
myList.Insert(4, 100);
Display(myList.ToArray());

// Insert Range.
Console.Write("Insert range {98, 97, 96} at index 8: ");
myList.InsertRange(8, new List<int>{ 98, 97, 96 });
Display(myList.ToArray());

// Remove.
Console.Write("After removing 97: ");
myList.Remove(97);
Display(myList.ToArray());

// RemoveAt.
Console.Write("After removing element at index 0: ");
myList.RemoveAt(0);
Display(myList.ToArray());



void Display<T>(IEnumerable<T> list)
{
    foreach (var item in list)
        Console.Write(item + " ");

    Console.WriteLine();
}
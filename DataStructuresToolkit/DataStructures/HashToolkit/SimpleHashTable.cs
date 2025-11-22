using System;
using System.Collections.Generic;

/// <summary>
/// A simple hash table implementation that stores integer keys using
/// separate chaining with an array of integer lists as buckets.
/// </summary>
/// <remarks>
/// Collision handling strategy: separate chaining using lists.
/// Average complexity:
/// - Insert: O(1)
/// - Contains: O(1)
/// - PrintTable: O(n)
/// Worst-case (all keys end up in the same bucket):
/// - Insert: O(n)
/// - Contains: O(n)
/// </remarks>
public class SimpleHashTable
{
    private readonly List<int>[] buckets;
    private readonly int size;

    /// <summary>
    /// Initializes a new instance of the SimpleHashTable class.
    /// </summary>
    /// <param name="size">The number of buckets in the table.</param>
    public SimpleHashTable(int size = 10)
    {
        this.size = size;
        buckets = new List<int>[size];

        for (int i = 0; i < size; i++)
        {
            buckets[i] = new List<int>();
        }
    }

    /// <summary>
    /// Computes the bucket index for a given key.
    /// </summary>
    /// <param name="key">The integer key to hash.</param>
    /// <returns>The index of the bucket where the key should be stored.</returns>
    private int Hash(int key)
    {
        return Math.Abs(key.GetHashCode()) % size;
    }

    /// <summary>
    /// Inserts a key into the hash table if it is not already present.
    /// </summary>
    /// <param name="key">The key to insert.</param>
    /// <remarks>
    /// Average complexity: O(1)  
    /// Worst-case: O(n) when many keys fall into the same bucket.
    /// </remarks>
    public void Insert(int key)
    {
        int index = Hash(key);

        if (!buckets[index].Contains(key))
        {
            buckets[index].Add(key);
        }
    }

    /// <summary>
    /// Checks whether the specified key is stored in the hash table.
    /// </summary>
    /// <param name="key">The key to search for.</param>
    /// <returns>True if the key exists; otherwise false.</returns>
    /// <remarks>
    /// Average complexity: O(1)  
    /// Worst-case: O(n) if many keys are in the same bucket.
    /// </remarks>
    public bool Contains(int key)
    {
        int index = Hash(key);
        return buckets[index].Contains(key);
    }

    /// <summary>
    /// Prints all buckets and their stored keys.
    /// </summary>
    /// <remarks>
    /// Complexity: O(n) with respect to the number of stored keys.
    /// </remarks>
    public void PrintTable()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Bucket {i}: ");

            if (buckets[i].Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(", ", buckets[i]));
            }
        }
    }

    /// <summary>
    /// Demonstrates collisions by inserting the keys 12, 22, and 37
    /// into a table of size 5, showing that they all hash into the same bucket.
    /// </summary>
    /// <remarks>
    /// All three keys resolve to the same bucket index because they have
    /// the same remainder when divided by 5:
    /// 12 mod 5 = 2  
    /// 22 mod 5 = 2  
    /// 37 mod 5 = 2  
    ///
    /// Each insertion is O(1) on average.  
    /// The demonstration performs three insertions for a total of O(1).
    /// Printing the table results in O(n) where n is the number of stored keys.
    /// </remarks>
    public static void Demo()
    {
        SimpleHashTable table = new SimpleHashTable(5);

        table.Insert(12);
        table.Insert(22);
        table.Insert(37);

        Console.WriteLine("Demonstrating collisions with keys 12, 22, and 37:");
        table.PrintTable();
    }
}

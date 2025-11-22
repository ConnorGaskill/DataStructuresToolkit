using System;
using System.Collections.Generic;

/// <summary>
/// Demonstrates the use of a string dictionary for storing phone numbers
/// and a string set for preventing duplicate entries.
/// </summary>
/// <remarks>
/// Features demonstrated:
/// - Using a dictionary that maps names to phone numbers.
/// - Using a set to avoid storing the same name multiple times.
/// - Checking for existing keys in the dictionary using ContainsKey.
/// - Checking for existing entries in the set using Contains.
/// Complexity notes:
/// - Dictionary operations: average O(1), worst-case O(n)
/// - Set operations: average O(1), worst-case O(n)
/// </remarks>
public static class AssociativeHelpers
{
    private static readonly Dictionary<string, string> phoneDirectory =
        new Dictionary<string, string>();

    private static readonly HashSet<string> uniqueNames =
        new HashSet<string>();

    /// <summary>
    /// Adds a contact name and phone number to the directory
    /// and adds the name to the set of unique names.
    /// </summary>
    /// <param name="name">The contact name.</param>
    /// <param name="phoneNumber">The phone number.</param>
    /// <remarks>
    /// Complexity:
    /// - Dictionary insertion: average O(1), worst-case O(n)
    /// - Set insertion: average O(1), worst-case O(n)
    /// </remarks>
    public static void AddContact(string name, string phoneNumber)
    {
        phoneDirectory[name] = phoneNumber;
        uniqueNames.Add(name);
    }

    /// <summary>
    /// Displays whether a given contact name is already stored
    /// in the dictionary and in the set.
    /// </summary>
    /// <param name="name">The name to check.</param>
    /// <remarks>
    /// Complexity:
    /// - Dictionary ContainsKey: average O(1), worst-case O(n)
    /// - Set Contains: average O(1), worst-case O(n)
    /// </remarks>
    public static void CheckContact(string name)
    {
        Console.WriteLine($"Dictionary ContainsKey('{name}'): {phoneDirectory.ContainsKey(name)}");
        Console.WriteLine($"Set Contains('{name}'): {uniqueNames.Contains(name)}");
    }

    /// <summary>
    /// Prints the contents of the phone directory
    /// and the set of unique names.
    /// </summary>
    /// <remarks>
    /// Complexity:
    /// - Printing dictionary entries: O(n)
    /// - Printing set entries: O(n)
    /// </remarks>
    public static void PrintData()
    {
        Console.WriteLine("Phone Directory:");
        foreach (var entry in phoneDirectory)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value}");
        }

        Console.WriteLine("Unique Names Set:");
        foreach (var name in uniqueNames)
        {
            Console.WriteLine($"  {name}");
        }
    }

    /// <summary>
    /// Clears all stored data in the dictionary and the set.
    /// Useful for repeated testing runs.
    /// </summary>
    /// <remarks>
    /// Complexity: O(n) for clearing both collections.
    /// </remarks>
    public static void Reset()
    {
        phoneDirectory.Clear();
        uniqueNames.Clear();
    }
}

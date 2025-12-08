namespace DataStructuresUtilities
{
    /// <summary>
    /// Utility class for generating random data.
    /// </summary>
    public static class RandomUtilities
    {
        /// <summary>
        /// Generates an array of random integers using the given length and numeric range.
        /// </summary>
        public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(minValue, maxValue);
            }

            return array;
        }

        /// <summary>
        /// Creates a list of random names chosen from a preset name pool.
        /// Used for generating simple mock data.
        /// </summary>
        public static List<string> GenerateRandomNamesList(int count)
        {
            string[] namePool = new string[]
            {
                "Alice", "Bob", "Charlie", "Diana", "Ethan",
                "Fiona", "George", "Hannah", "Ian", "Julia",
                "Kevin", "Laura", "Mike", "Nina", "Oscar",
                "Paula", "Quinn", "Rachel", "Sam", "Tina"
            };

            Random rand = new Random();
            List<string> result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(namePool.Length);
                result.Add(namePool[index]);
            }

            return result;
        }

        /// <summary>
        /// Creates an array of random names chosen from a preset name pool.
        /// Same as the List version, but returns a string array.
        /// </summary>
        public static string[] GenerateRandomNamesArray(int count)
        {
            string[] namePool = new string[]
            {
                "Alice", "Bob", "Charlie", "Diana", "Ethan",
                "Fiona", "George", "Hannah", "Ian", "Julia",
                "Kevin", "Laura", "Mike", "Nina", "Oscar",
                "Paula", "Quinn", "Rachel", "Sam", "Tina"
            };

            Random rand = new Random();
            string[] result = new string[count];

            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(namePool.Length);
                result[i] = namePool[index];
            }

            return result;
        }

        /// <summary>
        /// Shuffles an existing array by recreating it as a new random array.
        /// Note: This does NOT preserve the original values—it regenerates them.
        /// </summary>
        public static int[] Shuffle(int[] arr)
        {
            return GenerateRandomArray(arr.Length, arr.Min(), arr.Max());
        }
    }
}

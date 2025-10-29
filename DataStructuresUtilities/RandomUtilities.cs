namespace DataStructuresUtilities
{
    /// <summary>
    /// Utilities for random numbers
    /// </summary>
    public class RandomUtilities
    {
        /// <summary>
        /// Creates an array of random ints based on a given length, min value, and max value
        /// </summary>
        /// <param name="length">Desired size of the array</param>
        /// <param name="minValue">The minimum value of all random ints in the array</param>
        /// <param name="maxValue">The maximum value of all random ints in the array</param>
        /// <returns></returns>
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

        public static int[] Shuffle(int[] arr)
        {
           return arr = GenerateRandomArray(arr.Length, arr.Min(), arr.Max());

        }

    }
}

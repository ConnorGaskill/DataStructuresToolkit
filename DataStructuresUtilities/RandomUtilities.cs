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

    }
}

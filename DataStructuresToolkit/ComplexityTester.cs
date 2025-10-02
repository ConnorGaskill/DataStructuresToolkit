using DataStructuresUtilities;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Runs scenarios of various complexities
    /// </summary>
    public class ComplexityTester
    {
        /// <summary>
        /// Takes an array and returns the first index
        /// </summary>
        /// <param name="arr">The array used by the scenario</param>
        /// <remarks>Time complexity = O(1) due to returning the same index without looping</remarks>
        public static void RunConstantScenario(int[] arr)
        {

            arr[0] = 1;

        }
        /// <summary>
        /// Takes an array and loops through each element
        /// </summary>
        /// <param name="arr">The array used by the scenario</param>
        /// <remarks>Time complexity = O(n) due to looping over the array n times per call</remarks>
        public static void RunLinearScenario(int[] arr)
        {

            foreach (int i in arr) {
                _ = "searching";
            }
        }
        /// <summary>
        /// Takes an array and compares each element to every other element
        /// </summary>
        /// <param name="arr">The array used by the scenario</param>
        /// <remarks>Time complexity = O(n^2) due to the nested array that loops over every element n^2 times per call</remarks>
        public static void RunQuadraticScenario(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++) {

                for (int j = 0; j < arr.Length; j++) {
                    _ = "searching";

                }
            }
        }
    }
}

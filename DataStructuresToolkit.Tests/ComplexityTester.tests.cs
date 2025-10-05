using DataStructuresToolkit;
using DataStructuresUtilities;

namespace DataStructuresToolkit.Tests
{
    [TestFixture]
    public class ComplexityTesterTests
    {
        /// <summary>
        /// Passes arrays of various sizes
        /// Calls RunConstantScenario with each array
        /// Times how long each method call takes to complete
        /// Asserts the time to complete each method call is constant within 1 ms
        /// </summary>
        [Test]
        public void ConstantScenario_ShouldBeConstant()
        {
            int[] arr1 = RandomUtilities.GenerateRandomArray(1000, 1, 1000);
            int[] arr2 = RandomUtilities.GenerateRandomArray(10000, 1, 1000);
            int[] arr3 = RandomUtilities.GenerateRandomArray(100000, 1, 1000);


            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunConstantScenario(arr1));

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunConstantScenario(arr2));

            TimeSpan ts3 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunConstantScenario(arr3));

            TestContext.Out.WriteLine(ts1);
            TestContext.Out.WriteLine(ts2);
            TestContext.Out.WriteLine(ts3);

            Assert.That(ts1.TotalMilliseconds, Is.EqualTo(ts2.TotalMilliseconds).Within(1));
            Assert.That(ts2.TotalMilliseconds, Is.EqualTo(ts3.TotalMilliseconds).Within(1));

        }
        /// <summary>
        /// Passes arrays of various sizes
        /// Calls RunLinearScenario with each array
        /// Times how long each method call takes to complete
        /// Asserts the time to complete each method call increases linearly within 1 ms
        /// </summary>
        [Test]
        public void LinearScenario_ShouldBeLinear()
        {
            int[] arr1 = RandomUtilities.GenerateRandomArray(100000, 1, 1000);
            int[] arr2 = RandomUtilities.GenerateRandomArray(1000000, 1, 1000);
            int[] arr3 = RandomUtilities.GenerateRandomArray(10000000, 1, 1000);


            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunLinearScenario(arr1));

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunLinearScenario(arr2));

            TimeSpan ts3 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunLinearScenario(arr3));

            TestContext.Out.WriteLine(ts1);
            TestContext.Out.WriteLine(ts2);
            TestContext.Out.WriteLine(ts3);

            Assert.That(ts1.TotalMilliseconds, Is.EqualTo(ts2.TotalMilliseconds/10).Within(.5));
            Assert.That(ts2.TotalMilliseconds, Is.EqualTo(ts3.TotalMilliseconds/10).Within(.5));

        }
        /// <summary>
        /// Passes arrays of various sizes
        /// Calls RunQuadraticScenario with each array
        /// Times how long each method call takes to complete
        /// Asserts the time to complete each method call increases quadratically within 1 ms
        /// </summary>
        [Test]
        public void QuadraticScenario_ShouldBeQuadratic()
        {
            int[] arr1 = RandomUtilities.GenerateRandomArray(1000, 1, 1000);
            int[] arr2 = RandomUtilities.GenerateRandomArray(10000, 1, 1000);
            int[] arr3 = RandomUtilities.GenerateRandomArray(100000, 1, 1000);


            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunQuadraticScenario(arr1));

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunQuadraticScenario(arr2));

            TimeSpan ts3 = TimeUtilities.RunWithStopwatch(() => ComplexityTester.RunQuadraticScenario(arr3));

            TestContext.Out.WriteLine(ts1);
            TestContext.Out.WriteLine(ts2);
            TestContext.Out.WriteLine(ts3);

            Assert.That(ts1.TotalMilliseconds, Is.EqualTo(ts2.TotalMilliseconds / 100).Within(15));
            Assert.That(ts2.TotalMilliseconds, Is.EqualTo(ts3.TotalMilliseconds / 100).Within(15));

        }

    }
}

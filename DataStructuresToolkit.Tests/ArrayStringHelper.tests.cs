using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataStructuresToolkit;
using DataStructuresUtilities;

namespace DataStructuresToolkit.Tests
{
    [TestFixture]
    public class ArrayStringListHelpers_Tests
    {
        [Test]
        public void InsertIntoArray_InsertsValueCorrectly()
        {
            int[] arr = { 1, 2, 3, 4 };
            int[] result = ArrayStringListHelper.InsertIntoArray(arr, 2, 99);

            Assert.That(arr.Length + 1, Is.EqualTo(result.Length));
            Assert.That(result[2], Is.EqualTo(99));
            Assert.That(result[3], Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(1));
        }
        [Test]
        public void ConcatenateNamesBuilder_ShouldBeLinear()
        {
            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesBuilder(RandomUtilities.GenerateRandomNamesArray(100000)));

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesBuilder(RandomUtilities.GenerateRandomNamesArray(1000000)));

            TimeSpan ts3 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesBuilder(RandomUtilities.GenerateRandomNamesArray(10000000)));

            TestContext.Out.WriteLine(ts1);
            TestContext.Out.WriteLine(ts2);
            TestContext.Out.WriteLine(ts3);

            Assert.That(ts1.TotalMilliseconds, Is.EqualTo(ts2.TotalMilliseconds / 10).Within(5));
            Assert.That(ts2.TotalMilliseconds, Is.EqualTo(ts3.TotalMilliseconds / 10).Within(5));
        }

        [Test]
        public void DeleteFromArray_DeletesValueCorrectly()
        {
            int[] arr = { 1, 2, 3, 4 };
            int[] result = ArrayStringListHelper.DeleteFromArray(arr, 1);

            Assert.That(result.Length, Is.EqualTo(arr.Length - 1));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(3));
            Assert.That(result[2], Is.EqualTo(4));
        }

        [Test]
        public void ConcatenateNamesNaive_ShouldBeQuadratic()
        {
            TimeSpan ts1 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesNaive(RandomUtilities.GenerateRandomNamesArray(100)));

            TimeSpan ts2 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesNaive(RandomUtilities.GenerateRandomNamesArray(1000)));

            TimeSpan ts3 = TimeUtilities.RunWithStopwatch(() => ArrayStringListHelper.ConcatenateNamesNaive(RandomUtilities.GenerateRandomNamesArray(10000)));

            TestContext.Out.WriteLine(ts1);
            TestContext.Out.WriteLine(ts2);
            TestContext.Out.WriteLine(ts3);

            Assert.That(ts1.TotalMilliseconds, Is.EqualTo(ts2.TotalMilliseconds / 100).Within(5));
            Assert.That(ts2.TotalMilliseconds, Is.EqualTo(ts3.TotalMilliseconds / 100).Within(5));
        }

        [Test]
        public void InsertIntoList_InsertsValueCorrectly()
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };
            ArrayStringListHelper.InsertIntoList(list, 2, 99);

            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list[2], Is.EqualTo(99));
            Assert.That(list[3], Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo(1));
        }

        [Test]
        public void InsertIntoList_Throws_OnInvalidIndex()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayStringListHelper.InsertIntoList(list, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayStringListHelper.InsertIntoList(list, 4, 0));
        }
    }
}
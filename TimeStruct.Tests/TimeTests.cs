using NUnit.Framework;

namespace TimeStruct.Tests
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForToString))]
        public void ToStringTests(Time time, string str)
        {
            Assert.AreEqual(str, time.ToString());
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForToStringThroughObject))]
        public void ToStringThroughObjectTests(object time)
        {
            Assert.AreEqual("TimeStruct.Time", time.ToString());
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForMinutesProperty))]
        public void MinutesPropertyGetTests(Time time, int minutes)
        {
            Assert.AreEqual(minutes, time.Minutes);
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForHoursProperty))]
        public void HoursPropertyGetTests(Time time, int hour)
        {
            Assert.AreEqual(hour, time.Hours);
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForTwoParametersCtor))]
        public void CtorWithTwoParametersTests(Time time, int hour, int minutes)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(hour, time.Hours);
                Assert.AreEqual(minutes, time.Minutes);
            });
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForOneParameterCtor))]
        public void CtorWithOneParameterTests(Time time, int hour, int minutes)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(hour, time.Hours);
                Assert.AreEqual(minutes, time.Minutes);
            });
        }

        [Test]
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForTwoParametersCtor))]
        public void DeconstructTests(Time time, int expectedHours, int expectedMinutes)
        {
            var (hours, minutes) = time;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedHours, hours);
                Assert.AreEqual(expectedMinutes, minutes);
            });
        }
    }
}

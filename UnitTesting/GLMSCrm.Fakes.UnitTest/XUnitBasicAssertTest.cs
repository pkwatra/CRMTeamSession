using GLMSCrm.Fakes.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace GLMSCrm.Fakes.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class XUnitBasicAssertTest : IDisposable
    {
        /// <summary>
        /// We use constructor in XUnit for any test class level setup.
        /// This is equivalent to "TestFixtureSetUp" in NUnit.
        /// This code will execute before every testcase.
        /// </summary>
        public XUnitBasicAssertTest() {
            
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void MyFirstPassingTest()
        {
            Console.WriteLine("We are currently in my first test – well done!");
            Assert.True(true);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void MyFirstFailingTest()
        {
            Console.WriteLine("We are currently in my first test – well done!");
            Assert.False(true);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void InRangeInt()
        {
            int myValue = 100;
            int min = 1;
            int max = 10;
            Assert.InRange(myValue, min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void InRangeDateTime()
        {
            Assert.InRange(new DateTime(2009, 1, 1), new DateTime(2000, 1, 1), new DateTime(2008, 1, 6));
        }

        /// <summary>
        /// Ignore a testcase.
        /// If we want a test to be skipped, then we can set the 
        /// Skip attribute and give a reason.
        /// </summary>
        [Fact(Skip = "Takes too long")]
        public void SkippedTest()
        {
            //Never executed.
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void AsertionExamples()
        {
            Console.WriteLine("AccountTests.AsertionExamples()");

            Assert.Contains("n", "FNZ", StringComparison.CurrentCultureIgnoreCase);
            Assert.Contains("a", new List<String> { "A", "B" }, StringComparer.CurrentCultureIgnoreCase);

            Assert.DoesNotContain("n", "FNZ", StringComparison.CurrentCulture);
            Assert.DoesNotContain("a", new List<String> { "A", "B" }, StringComparer.CurrentCulture);

            Assert.Empty(new List<String>());
            Assert.NotEmpty(new List<String> { "A", "B" });

            Assert.Equal(1, 1);
            Assert.Equal(1.13, 1.12, 1); // Precsions Num DP
            Assert.Equal(new List<String> { "A", "B" }, new List<String> { "a", "b" }, StringComparer.CurrentCultureIgnoreCase);

            Assert.NotEqual(1, 2);
            Assert.NotEqual(new List<String> { "A", "B" }, new List<String> { "a", "b" }, StringComparer.CurrentCulture);

            Assert.NotNull(false);
            Assert.Null(null);

            Assert.NotInRange(-1, 0, 10);

            Assert.IsType(Type.GetType("System.Int32"), 1);
            Assert.IsNotType(Type.GetType("System.Double"), 1);

            var foo = new object();
            var moo = new object();

            Assert.Same(foo, foo);
            Assert.NotSame(foo, moo);
        }

        /// <summary>
        /// We use this as test level tear down.
        /// This is equivalent to "TestFixtureTearDown" in NUnit.
        /// This code will be executed after every test case.
        /// </summary>
        public void Dispose()
        { 
            Console.WriteLine("We are currently disposing.");
        }
    }
}

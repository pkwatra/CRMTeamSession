using GLMSCrm.Fakes.Entity;
using Ploeh.AutoFixture.Xunit;
using System;
using Xunit;

namespace GLMSCrm.Fakes.UnitTest
{
    [Category("DataDrivenTest")]
    public class DataDrivenTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        [Theory]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        [InlineData(10, true)]
        public void TestNumberGreatorThenZero(int num, bool expectedResult)
        {
            Assert.Equal(expectedResult, num > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        [Theory]
        [MemberData("TestData", MemberType = typeof(PropertyTestDataSource))]
        public void TestNumberGreatorThenTen(int num, bool expectedResult)
        {
            Assert.Equal(expectedResult, num > 10);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        [Theory]
        [RangeData(1, 10)]
        public void CustomDataDriven(int num)
        {
            Console.WriteLine("Cuttent Number : " + num);
            Assert.True(true);
        }

        /// <summary>
        /// With AutoData attribute we can even fill the 
        /// random data into value typs.
        /// </summary>
        /// <param name="num"></param>
        [Theory]
        [AutoData()]
        public void AutoFixtureDataDriven(int number1, int number2)
        {
            Console.WriteLine("Cuttent Numbers : " + number1 + " - " + number2);
            Assert.True(true);
        }

        /// <summary>
        /// With AutoData attribute we can even fill the 
        /// random data into complex type Entity.
        /// </summary>
        /// <param name="employee"></param>
        [Theory]
        [AutoData()]
        public void AutoFixtureComplexTypeDataDriven(Employee employee)
        {
            Assert.True(true);
        }

        /// <summary>
        /// We can have multiple InlineAutoData attributes on a method. 
        /// One for each parameter. If all par5ameters are covered 
        /// by the first attribute the others are ignored.
        /// </summary>
        /// <param name="employee"></param>
        [Theory]
        [InlineAutoData()]
        [InlineAutoData(22)]
        public void InlineAutoFixtureDataDriven(int number1, int number3, int number2)
        {
            Assert.True(true);
        }
    }
}

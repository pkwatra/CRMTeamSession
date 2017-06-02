using GLMSCrm.Fakes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GLMSCrm.Fakes.UnitTest
{
    [Category("EqualsVariationTest")]
    public class EqualsVariation
    {
        public class PersonWithEquals
        {
            public string Name { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null) { return false; }

                var e = obj as PersonWithEquals;

                if (e == null)
                {
                    return false;
                }

                return e.Name == Name;
            }
        }

        public class FirstLetterEqualityComparator :IEqualityComparer<PersonWithEquals> 
        {
            public bool Equals(PersonWithEquals person1, PersonWithEquals person2)
            {
                return person1.Name[0] == person2.Name[0];
            }

            public int GetHashCode(PersonWithEquals obj) {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ComapareValueTypes()
        {
            //This will pass.
            Assert.Equal(15, Math.Sqrt(15 * 15));
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ComapareReferenceTypes()
        {
            var e1 = new Employee { EmpFName = "Name" };
            var e2 = new Employee { EmpFName = "Name" };

            // This will fail as our assert is checking that both 
            // e1, e2 are pointing to same memory location.
            //Assert.Equal(e1, e2);

            var e3 = e1;

            //This will pass.
            Assert.Equal(e1, e3);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ComapareReferenceTypesWithOverriddenEquals()
        {
            var e1 = new PersonWithEquals { Name = "MsCrm" };
            var e2 = new PersonWithEquals { Name = "MsCrm" };

            Assert.Equal(e1, e2);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CustomEqualityComparator()
        {
            var e1 = new PersonWithEquals { Name = "MyName" };
            var e2 = new PersonWithEquals { Name = "MsCrm" };

            Assert.Equal(e1, e2, new FirstLetterEqualityComparator());
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EqualWithCollection()
        {
            IEnumerable<int> range1 = Enumerable.Range(1, 10);
            IEnumerable<int> range2 = Enumerable.Range(1, 10);

            Assert.Equal(range1, range2);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void DecimalWithPrecision()
        {
            var number1 = new Decimal(22.113); // 22.11
            var number2 = new Decimal(22.118); // 22.12

            // This will fail as we want to check 
            // precision upto 2 decimal places.
            Assert.Equal(number1, number2, 2);
        }
    }
}

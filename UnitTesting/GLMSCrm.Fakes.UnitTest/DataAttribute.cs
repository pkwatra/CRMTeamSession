using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace GLMSCrm.Fakes.UnitTest
{
    public class RangeDataAttribute : DataAttribute
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public RangeDataAttribute(int start, int count) {
            Start = start;
            Count = count;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return Enumerable.Range(Start, Count).Select(i => new object[] { i });
        }
    }
}

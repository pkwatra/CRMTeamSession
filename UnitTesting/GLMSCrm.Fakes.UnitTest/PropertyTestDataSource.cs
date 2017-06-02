using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.UnitTest
{
    public class PropertyTestDataSource
    {
        private static List<object[]> _data = new List<object[]>
                                                  {
                                                      new object[] { 19, true},
                                                      new object[] { 10, false},
                                                      new object[] { 110, true},
                                                      new object[] { -2, false}
                                                  };

        public static IEnumerable<object[]> TestData {
            get { return _data; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace GLMSCrm.Fakes.UnitTest
{
    //This is old implimentation, Now this is obsolete.
    //public class CategoryAttribute : TraitAttribute
    //{
    //    public CategoryAttribute(string categoryName) : base("Category", categoryName)
    //    {

    //    }
    //}

    [TraitDiscoverer("GLMSCrm.Fakes.UnitTest.CategoryDiscoverer", "GLMSCrm.Fakes.UnitTest")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CategoryAttribute : Attribute, ITraitAttribute
    {
        public string CategoryName { get; set; }

        public CategoryAttribute(string categoryName)
        {
            CategoryName = categoryName;
        }
    }

    public class CategoryDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return new KeyValuePair<string, string>("Category", traitAttribute.GetConstructorArguments().First().ToString());
        }
    }
}
